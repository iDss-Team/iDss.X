﻿using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;

namespace iDss.X.Services
{
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
}