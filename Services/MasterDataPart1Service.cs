
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;

namespace iDss.X.Services
{
    public class MasterDataPart1Service
    {
        private readonly AppDbContext _db;

        public MasterDataPart1Service(AppDbContext context)
        {
            _db = context;
        }

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        //private static readonly ConcurrentDictionary<Type, Func<IEnumerable<TModel>, string, SortOrder, IEnumerable<TModel>>> SortLambdaCache = new();

        #region "Province"
        public async Task<List<Province>> GetProvinceAsync()
        {
            var result = _db.mdt_province
                .OrderByDescending(c => c.provid)
                .ToListAsync();
            return await result;
        }

        public async Task<List<Province>> LoadProvinceAsync()
        {
            var result = _db.mdt_province
                                .Select(p => new Province()
                                {
                                    provid = p.provid,
                                    provname = p.provname
                                })
                .ToListAsync();
            return await result;
        }
        #endregion

        #region "City"
        public async Task<List<City>> GetCityAsync()
        {
            var result = _db.mdt_city
                .Include(c => c.Province)
                .OrderByDescending(c => c.cityid)
                .ToListAsync();
            return await result;
        }

        public async Task<List<City>> LoadCityAsync()
        {
            var result = _db.mdt_city
                                .Select(p => new City()
                                {
                                    cityid = p.cityid,
                                    cityname = p.cityname,
                                    Province = p.Province
                                })
                .ToListAsync();
            return await result;
        }
        #endregion

        #region "District"
        public async Task<List<District>> GetDistrictAsync()
        {
            var result = _db.mdt_district
                .Include(c => c.City)
                .OrderByDescending(c => c.distid)
                .ToListAsync();
            return await result;
        }

        public async Task<List<District>> LoadDistrictAsync()
        {
            var result = _db.mdt_district
                                .Select(p => new District()
                                {
                                    distid = p.distid,
                                    distname = p.distname,
                                    City = p.City
                                })
                .ToListAsync();
            return await result;
        }
        #endregion

        #region "Village"
        public async Task<List<Village>> GetVillageAsync()
        {
            var result = _db.mdt_village
                .Include(c => c.District)
                .OrderByDescending(c => c.villid)
                .ToListAsync();
            return await result;
        }

        public async Task<List<Village>> LoadVillageAsync()
        {
            var result = _db.mdt_village
                                .Select(p => new Village()
                                {
                                    villid = p.villid,
                                    villname = p.villname,
                                    District = p.District
                                })
                .ToListAsync();
            return await result;
        }

        public IEnumerable<Village> GetAllVillages()
        {
            return _db.mdt_village.AsNoTracking().ToList();
        }

        #endregion

        #region "CIF"

        #endregion

        #region "Account"

        #endregion
    }
}
