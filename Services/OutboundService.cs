using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;
using iDss.X.Models.Dto;
using Humanizer;

namespace iDss.X.Services
{
    // awb inventory service
    public class OutboundService
    {
        private readonly AppDbContext _db;

        public OutboundService(AppDbContext context)
        {
            _db = context;
        }

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        public async Task<List<Province>> GetAllProvinceAsync()
        {
            return await _db.mdt_province
                .OrderBy(p => p.provname)
                .ToListAsync();
        }

        public async Task<List<Branch>> GetAllBranchAsync()
        {
            return await _db.mdt_branch
                .OrderBy(b => b.branchname)
                .ToListAsync();
        }

        public async Task<List<Branch>> GetBranchByProv(string provid)
        {
            var branches = await (from b in _db.mdt_branch
                                  join v in _db.mdt_village on b.villid equals v.villid
                                  join d in _db.mdt_district on v.distid equals d.distid
                                  join c in _db.mdt_city on d.cityid equals c.cityid
                                  where c.provid == provid
                                  select b)
                         .ToListAsync();

            return branches;
        }

        public async Task GenerateAwbAsync(int branchId, int totalRequest, string currentUser)
        {
            var branch = await _db.mdt_branch
                .Include(b => b.Village)
                .ThenInclude(v => v.District)
                .ThenInclude(d => d.City)
                .ThenInclude(c => c.Province)
                .FirstOrDefaultAsync(b => b.branchid == branchId);

            // ambil provid
            var provid = branch?.Village?.District?.City?.Province?.provid;

            if (branch == null)
            {
                throw new Exception("Branch tidak ditemukan");
            }

            var now = DateTime.UtcNow;
            string year = now.ToString("yy");
            string month = now.ToString("MM");

            string provCode = provid?.PadLeft(2, '0') ?? "00";
            string branchcode = branch.branchcode?.PadLeft(3, '0') ?? "000";

            // ambil semua awb yg dibuat bulan dan tahun ini oleh branch ini
            var prefix = $"{provCode}{branchcode}{year}{month}";
            var existingAwbs = await _db.mdt_awbinventory
                .Where(a => a.branchid == branchId && a.awb.StartsWith(prefix))
                .Select(a => a.awb)
                .ToListAsync();

            int maxSerial = existingAwbs
                .Select(a =>
                {
                    if (a.Length >= prefix.Length + 4 && int.TryParse(a.Substring(prefix.Length, 4), out int serial))
                        return serial;
                    return 0;
                }).DefaultIfEmpty(0).Max();

            var awbs = new List<AWBInventory>();

            for (int i = 1; i <= totalRequest; i++)
            {
                int serial = maxSerial + i;
                string serialStr = serial.ToString("D4");

                string awbCode = $"{prefix}{serialStr}";

                var awbInventory = new AWBInventory
                {
                    awb = awbCode,
                    branchid = branchId,
                    userlock = currentUser,
                    createddate = now,
                    createdby = currentUser
                };

                awbs.Add(awbInventory);
            }

            _db.mdt_awbinventory.AddRange(awbs);
            await _db.SaveChangesAsync();
        }

        public async Task<int> GetAvailableAwbCountAsync(int branchId)
        {
            return await _db.mdt_awbinventory
                .Where(a => a.branchid == branchId)
                .CountAsync();
        }
    }

    // entry data primary service
    public class EntryDataPrimaryService
    {
        private readonly AppDbContext _db;

        public EntryDataPrimaryService(AppDbContext context)
        {
            _db = context;
        }

        public async Task<List<City>> GetAllCityAsync()
        {
            return await _db.mdt_city
                .OrderBy(c => c.cityname)
                .ToListAsync();
        }
        public async Task<bool> SaveEntryDataPrimaryASync(EntryDataPrimaryDto edp)
        {
            using var entryData = await _db.Database.BeginTransactionAsync();

            try
            {
                if (edp.Shipment != null)
                {
                    // Tambahkan ShipmentDetail
                    _db.trx_shipmentdetail.Add(edp.Shipment);
                }

                if (edp.Shipper != null)
                {
                    // Pastikan awb Shipper sesuai dengan Shipment (jika diperlukan)
                    edp.Shipper.awb = edp.Shipment?.awb;
                    _db.trx_shipper.Add(edp.Shipper);
                }

                if (edp.Consignee != null)
                {
                    // Pastikan awb Consignee sesuai dengan Shipment (jika diperlukan)
                    edp.Consignee.awb = edp.Shipment?.awb;
                    _db.trx_consignee.Add(edp.Consignee);
                }

                await _db.SaveChangesAsync();
                await entryData.CommitAsync();
                return true;
            }
            catch
            {
                await entryData.RollbackAsync(); // Penting: rollback kalau gagal
                return false;
            }
        }
    }
}