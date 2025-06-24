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
    public class OutboundService
    {
        private readonly AppDbContext _db;
        private readonly MasterDataPart1Service _service1;
        private readonly MasterDataPart2Service _service2;
        private readonly MasterDataPart3Service _service3;

        public OutboundService(AppDbContext context, MasterDataPart1Service service1, MasterDataPart2Service service2, MasterDataPart3Service service3)
        {
            _db = context;
            _service1 = service1;
            _service2 = service2;
            _service3 = service3;
        }

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        #region "Dropdown Data Loaders"

        public async Task<List<SelectedItem>> GetCityDropdownItemsAsync()
        {
            var city = await _service1.LoadCityAsync();

            return city
            .Select(c => new SelectedItem(c.cityname, c.cityname))
            .ToList();
        }

        public async Task<List<SelectedItem>> GetDistrictDropdownItemsAsync()
        {
            var district = await _service1.LoadDistrictAsync();

            return district
            .Select(d => new SelectedItem(d.distid, d.distname))
            .ToList();
        }

        public async Task<List<SelectedItem>> GetProvinceDropdownItemsAsync()
        {
            var province = await _service1.LoadProvinceAsync();

            return province
            .Select(p => new SelectedItem(p.provname, p.provname))
            .ToList();
        }

        public async Task<List<SelectedItem>> GetBranchDropdownItemsAsync()
        {
            var branch = await _service3.LoadBranchAsync();

            return branch
            .Select(b => new SelectedItem(b.branchid.ToString(), b.branchname))
            .ToList();
        }

        public async Task<List<SelectedItem>> GetPackingTypeDropdownItemsAsync()
        {
            var packingTypes = await _service1.GetPackingTypeComboAsync();

            var items = packingTypes
             .Select(p => new SelectedItem(p.packingname, p.packingname))
             .ToList();

            // Tambahkan item awal sebagai placeholder
            items.Insert(0, new SelectedItem("", "Type") { Active = true });

            return items;
        }

        public async Task<List<SelectedItem>> GetPackingSizeDropdownItemsAsync()
        {
            var packingSize = await _service1.GetPackingSizeComboAsync();

            var items = packingSize
             .Select(s => new SelectedItem(s.sizename, s.sizename))
             .ToList();

            // Tambahkan item awal sebagai placeholder
            items.Insert(0, new SelectedItem("", "Size") { Active = true });

            return items;
        }

        public List<SelectedItem> GetDeliveryTypeOptions()
        {
            return new List<SelectedItem>
            {
                new("PAKET", "PAKET"),
                new("POLIS", "POLIS"),
                new("DOCUMENT", "DOCUMENT"),
                new("FOOD", "FOOD"),
                new("MAJALAH", "MAJALAH"),
                new("VOUCHER", "VOUCHER"),
                new("BULETIN", "BULETIN"),
                new("VALUABLE GOODS", "VALUABLE GOODS"),
                new("HEAVY CARGO", "HEAVY CARGO"),
                new("OBAT", "OBAT"),
                new("OTHERS", "OTHERS")
            };
        }

        public List<SelectedItem> GetServiceTypeOptions()
        {
            return new List<SelectedItem>
            {
                new("OVERNIGHT", "OVERNIGHT SERVICE"),
                new("REGULAR", "REGULAR SERVICE"),
                new("SAME DAY", "SAME DAY SERVICE"),
                new("TRUCK", "TRUCK SERVICE")
            };
        }

        public List<SelectedItem> GetLinehaulOptions()
        {
            return new List<SelectedItem>
            {
                new("UDARA", "UDARA"),
                new("DARAT", "DARAT"),
                new("LAUT", "LAUT")
            };
        }

        #endregion "Dropdown Data Loaders"

        #region "AWB Inventory"

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

        public async Task<AWBInventory?> GetAndLockAvailableAwbAsync(int branchId, string currentUser)
        {
            try
            {
                var awbEntity = await _db.mdt_awbinventory
                    .AsNoTracking()
                    .Where(x => x.branchid == branchId
                     && x.userlock == "admin"
                     && !_db.trx_shipmentdetail.Any(s => s.awb == x.awb))
                    .OrderBy(x => x.id)
                    .FirstOrDefaultAsync();

                if (awbEntity == null)
                    return null;

                _db.Attach(awbEntity);
                awbEntity.userlock = currentUser;
                _db.Entry(awbEntity).Property(x => x.userlock).IsModified = true;

                return awbEntity;
            }
            catch
            {
                throw;
            }
        }

        #endregion "AWB Inventory"

        #region "Entry Data Primarry"

        public async Task<bool> SaveEntryDataPrimaryASync(EntryDataPrimaryDto edp)
        {
            using var entryData = await _db.Database.BeginTransactionAsync();

            try
            {
                var awbEntity = await GetAndLockAvailableAwbAsync(edp.Shipper.branchid, "system");
                if (awbEntity == null)
                {
                    throw new Exception("AWB tidak tersedia.");
                }

                var awb = awbEntity.awb; // ambil awb string-nya

                if (edp.Shipment != null) edp.Shipment.awb = awb;
                if (edp.Shipper != null) edp.Shipper.awb = awb;
                if (edp.Consignee != null) edp.Consignee.awb = awb;

                if (edp.Shipment != null)
                {
                    _db.trx_shipmentdetail.Add(edp.Shipment);
                }

                if (edp.Shipper != null)
                {
                    _db.trx_shipper.Add(edp.Shipper);
                }

                if (edp.Consignee != null)
                {
                    System.Console.WriteLine("BranchId: " + edp.Consignee.branchid);
                    _db.trx_consignee.Add(edp.Consignee);
                }

                //await _db.SaveChangesAsync();
                // 🔍 Tambahkan debug Id di sini sebelum SaveChangesAsync
                System.Console.WriteLine($"DEBUG: Shipment.Id = {edp.Shipment?.id}");
                System.Console.WriteLine($"DEBUG: Shipper.Id = {edp.Shipper?.id}");
                System.Console.WriteLine($"DEBUG: Consignee.Id = {edp.Consignee?.id}");

                var affectedRows = await _db.SaveChangesAsync();

                //var affectedRows = await _db.SaveChangesAsync();
                System.Console.WriteLine($"Jumlah record tersimpan: {affectedRows}");

                await entryData.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await entryData.RollbackAsync(); // Penting: rollback kalau gagal
                System.Console.WriteLine("Gagal simpan: " + ex.Message);
                if (ex.InnerException != null)
                {
                    System.Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                return false;
            }
        }

        #endregion "Entry Data Primarry"
    }
}