using Microsoft.EntityFrameworkCore;
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
    }
}