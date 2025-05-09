
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;

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

        public Task<QueryData<Province>> OnQueryProvinceAsync(QueryPageOptions options)
        {
            var items = _db.mdt_province.ToList();

            var isSearched = false;

            if (options.SearchModel is Province province)
            {
                if (!string.IsNullOrEmpty(province.provname))
                {
                    items = items.Where(item => item.provname?.Contains(province.provname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }



                isSearched = !string.IsNullOrEmpty(province.provname);
            }

            if (options.Searches.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Province>(FilterLogic.Or)).ToList();
            }


            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Province>()).ToList();
                isFiltered = true;
            }

            var total = items.Count();

            return Task.FromResult(new QueryData<Province>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });



        }




        public async Task<bool> SaveProvinceAsync(Province data, ItemChangedType changedType)
        {
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    //data.createdby = "System";
                    //data.createddate = DateTime.Now;
                    _db.mdt_province.Add(data);
                }
                //else if (changedType == ItemChangedType.Update)
                //{
                //    _db.mdt_city.Update(data);
                //}
                else
                {
                    var existingEntity = await _db.mdt_province.FindAsync(data.provid);
                    if (existingEntity != null)
                    {
                        _db.Entry(existingEntity).State = EntityState.Detached;
                    }

                    _db.Attach(data);
                    _db.Entry(data).State = EntityState.Modified;

                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }

        }


        public async Task<bool> DeleteProvinceByIDAsync(IEnumerable<Province> provincies)
        {
            try
            {
                foreach (var province in provincies)
                {
                    var existingEntity = await _db.mdt_province.FindAsync(province.provid);
                    if (existingEntity != null)
                    {
                        _db.mdt_province.Remove(existingEntity);
                    }
                }
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
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

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _db.mdt_city.ToListAsync();
        }

        public Task<QueryData<City>>OnQueryCityAsync(QueryPageOptions options){
            var items = _db.mdt_city.ToList();

            var isSearched = false;

            if(options.SearchModel is City city)
            {
                if (!string.IsNullOrEmpty(city.cityname))
                {
                    items = items.Where(item => item.cityname?.Contains(city.cityname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }
                if (!string.IsNullOrEmpty(city.citycode))
                {
                    items = items.Where(item => item.citycode?.Contains(city.citycode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }


                isSearched = !string.IsNullOrEmpty(city.cityname) || !string.IsNullOrEmpty(city.citycode);
            }

            if (options.Searches.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<City>(FilterLogic.Or)).ToList();
            }


            var isFiltered = false;
            if(options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<City>()).ToList();
                isFiltered = true;
            }

            var total = items.Count();

            return Task.FromResult(new QueryData<City>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });



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

        public async Task<bool> SaveCityAsync(City data, ItemChangedType changedType)
        {
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    //data.createdby = "System";
                    //data.createddate = DateTime.Now;
                    _db.mdt_city.Add(data);
                }
                //else if (changedType == ItemChangedType.Update)
                //{
                //    _db.mdt_city.Update(data);
                //}
                else
                {
                    var existingEntity = await _db.mdt_city.FindAsync(data.cityid);
                    if (existingEntity != null)
                    {
                        _db.Entry(existingEntity).State = EntityState.Detached;
                    }

                    _db.Attach(data);
                    _db.Entry(data).State = EntityState.Modified;

                }
                   await _db.SaveChangesAsync();
                   return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }

        }


        public async Task<bool>DeleteCityByIDAsync(IEnumerable<City> cities)
        {
            try
            {
                foreach(var city in cities)
                {
                    var existingEntity = await _db.mdt_city.FindAsync(city.cityid);
                    if (existingEntity != null)
                    {
                        _db.mdt_city.Remove(existingEntity);
                    }
                }
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
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
