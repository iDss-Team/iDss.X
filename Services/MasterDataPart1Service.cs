
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Net.NetworkInformation;

namespace iDss.X.Services
{
    public class MasterDataPart1Service
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public MasterDataPart1Service(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        //private static readonly ConcurrentDictionary<Type, Func<IEnumerable<TModel>, string, SortOrder, IEnumerable<TModel>>> SortLambdaCache = new();

        #region "Country"

        public async Task<List<Country>> GetCountryAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = await _context.mdt_country
                .AsNoTracking()
                .OrderByDescending(c => c.createddate)
                .ToListAsync();

            return result;
        }

        public async Task<(List<Country> Items, int TotalCount)> GetCountriesPagedAsync(int pageIndex, int pageSize)
        {
            using var _context = _contextFactory.CreateDbContext();

            var query = _context.mdt_country
                .AsNoTracking();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.countrycode)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }



        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_country.ToListAsync();
        }

        public async Task<Country?> GetCountryByCountryCodeAsync(string countrycode)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_country.FirstOrDefaultAsync(a => a.countrycode == countrycode);
        }



        public Task<QueryData<Country>> OnQueryCountryAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_country
            .AsNoTracking()
            .ToList();


            var isSearched = false;

            if (options.SearchModel is Country country)
            {
                if (!string.IsNullOrEmpty(country.countrycode))
                {
                    items = items.Where(item => item.countrycode?.Contains(country.countrycode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }
                if (!string.IsNullOrEmpty(country.countryname))
                {
                    items = items.Where(item => item.countryname?.Contains(country.countryname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }


                isSearched = !string.IsNullOrEmpty(country.countryname) || !string.IsNullOrEmpty(country.countrycode);
            }

            if (options.Searches.Any())
            {
                items = items.Where(options.Searches.GetFilterFunc<Country>(FilterLogic.Or)).ToList();
            }


            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Country>()).ToList();
                isFiltered = true;
            }

            var total = items.Count();


            return Task.FromResult(new QueryData<Country>
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSearch = isSearched
            });



        }

        public async Task<bool> CreateCountryAsync(Country data)
        {
            using var _context = _contextFactory.CreateDbContext();
            bool result;
            try
            {
                _context.mdt_country.Add(data);
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                System.Console.WriteLine($"Error in CreateCountryAsync: {ex.Message}");
                result = false;
            }
            return result;
        }




        public async Task<List<Country>> LoadCountryAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_country
                                .Select(p => new Country()
                                {
                                    countrycode = p.countrycode,
                                    countryname = p.countryname,
                                    isoalpha3 = p.isoalpha3,
                                    phonecode = p.phonecode,
                                    createdby = p.createdby,
                                    createddate = p.createddate,
                                    flag = p.flag
                                })
                .ToListAsync();
            return await result;
        }



        public async Task<bool> SaveCountryAsync(Country data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    //data.createdby = "System";
                    //data.createddate = DateTime.Now;
                    _context.mdt_country.Add(data);
                }
                //else if (changedType == ItemChangedType.Update)
                //{
                //    _db.mdt_city.Update(data);
                //}
                else
                {
                    var existingEntity = await _context.mdt_country.FindAsync(data.countrycode);
                    if (existingEntity != null)
                    {
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;

                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public async Task<bool> UpdateCountryAsync(string countrycode , Country updatedCountry)
        {
            using var _context = _contextFactory.CreateDbContext();
            var data = await _context.mdt_country.FirstOrDefaultAsync(a => a.countrycode == countrycode);
            if (data == null)
            {
                return false;
            }
            data.countryname = updatedCountry.countryname;
            data.isoalpha3 = updatedCountry.isoalpha3;
            data.phonecode = updatedCountry.phonecode;
            data.flag = updatedCountry.flag;


            _context.Entry(data).State = EntityState.Modified;

            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                System.Console.WriteLine($"SaveChanges affected rows: {affectedRows}");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in Update District Async: {ex.Message}");
                return false;
            }
        }




        public async Task<bool> DeleteCountryAsync(string countrycode)
        {
            using var _context = _contextFactory.CreateDbContext();
            var country = await _context.mdt_country.FirstOrDefaultAsync(a => a.countrycode == countrycode);

            if (country == null)
            {
                return false;
            }

            _=_context.mdt_country.Remove(country);
            await _context.SaveChangesAsync();
            return true;

        }


        #endregion
        #region "Province"
        public async Task<List<Province>> GetProvinceAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_province
                .OrderByDescending(c => c.provid)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public async Task<List<Province>> LoadProvinceAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_province
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
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_province.ToList();

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
                items = items.Where(options.Searches.GetFilterFunc<Province>(FilterLogic.Or)).ToList();
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


        public async Task<string> GenerateCityIdByProvinceAsync(string provid)
        {
            using var _context = _contextFactory.CreateDbContext();

            var cityIds = await _context.mdt_city
                .Where(c => c.cityid.StartsWith(provid))
                .Select(c => c.cityid)
                .ToListAsync();

            // Extract the last two digits, parse them as int, and find the max
            int maxSuffix = cityIds
                .Select(id => id.Length >= 4 ? int.Parse(id.Substring(2, 2)) : 0)
                .DefaultIfEmpty(0)
                .Max();

            // Increment and pad to ensure two digits
            int nextSuffix = maxSuffix + 1;
            return $"{provid}{nextSuffix.ToString("D2")}";
        }




        public async Task<bool> SaveProvinceAsync(Province data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    //data.createdby = "System";
                    //data.createddate = DateTime.Now;
                    _context.mdt_province.Add(data);
                }
                //else if (changedType == ItemChangedType.Update)
                //{
                //    _db.mdt_city.Update(data);
                //}
                else
                {
                    var existingEntity = await _context.mdt_province.FindAsync(data.provid);
                    if (existingEntity != null)
                    {
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;

                }
                await _context.SaveChangesAsync();
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
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                foreach (var province in provincies)
                {
                    var existingEntity = await _context.mdt_province.FindAsync(province.provid);
                    if (existingEntity != null)
                    {
                        _context.mdt_province.Remove(existingEntity);
                    }
                }
                await _context.SaveChangesAsync();
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
            using var _context = _contextFactory.CreateDbContext();
            var result = await _context.mdt_city
                .Include(c => c.Province)
                .AsNoTracking()
                .OrderByDescending(c => c.cityid)
                .ToListAsync();

            foreach (var item in result)
            {
                System.Console.WriteLine($"City : {item.cityname}, Province : {(item.Province != null ? item.Province.provname : "NULL")}");
            }

            return result;
        }

        public async Task<(List<City> Items, int TotalCount)> GetCitiesPagedAsync(int pageIndex, int pageSize)
        {
            using var _context = _contextFactory.CreateDbContext();

            var query = _context.mdt_city
                .Include(c => c.Province)
                .AsNoTracking();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.cityid)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }



        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_city.ToListAsync();
        }

        public async Task<City?> GetCityByCityIdAsync(string cityid)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_city.FirstOrDefaultAsync(a => a.cityid == cityid);
        }



        public Task<QueryData<City>> OnQueryCityAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_city
      .Include(c => c.Province)
      .AsNoTracking()
      .ToList();


            var isSearched = false;

            if (options.SearchModel is City city)
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
                items = items.Where(options.Searches.GetFilterFunc<City>(FilterLogic.Or)).ToList();
            }


            var isFiltered = false;
            if (options.Filters.Any())
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

        public async Task<bool> CreateCityAsync(City data)
        {
            using var _context = _contextFactory.CreateDbContext();
            bool result;
            try
            {
                _context.mdt_city.Add(data);
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                System.Console.WriteLine($"Error in CreateCityAsync: {ex.Message}");
                result = false;
            }
            return result;
        }




        public async Task<List<City>> LoadCityAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_city
                                .Select(p => new City()
                                {
                                    cityid = p.cityid,
                                    cityname = p.cityname,
                                    Province = p.Province
                                })
                .ToListAsync();
            return await result;
        }


        public async Task<List<string>> GetHubCodesByCityCodeAsync(string cityCode)
        {
            using var _context = _contextFactory.CreateDbContext();
            var hubCodes = await _context.mdt_city
                .Where(c => c.citycode == cityCode)
                .Select(c => c.hubcode)
                .Distinct()
                .ToListAsync();
            return hubCodes;
        }

        public async Task<bool> SaveCityAsync(City data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    //data.createdby = "System";
                    //data.createddate = DateTime.Now;
                    _context.mdt_city.Add(data);
                }
                //else if (changedType == ItemChangedType.Update)
                //{
                //    _db.mdt_city.Update(data);
                //}
                else
                {
                    var existingEntity = await _context.mdt_city.FindAsync(data.cityid);
                    if (existingEntity != null)
                    {
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;

                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public async Task<bool> UpdateCityAsync(string cityid, City updatedCity)
        {
            using var _context = _contextFactory.CreateDbContext();
            var data = await _context.mdt_city.FirstOrDefaultAsync(a => a.cityid == cityid);
            if (data == null)
            {
                return false;
            }
            data.cityname = updatedCity.cityname;
            data.citymerger = updatedCity.citymerger;
            data.citycode = updatedCity.citycode;
            data.hubcode = updatedCity.hubcode;
            data.provid = updatedCity.provid;

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                System.Console.WriteLine($"SaveChanges affected rows: {affectedRows}");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in Update District Async: {ex.Message}");
                return false;
            }
        }




        public async Task<bool> DeleteCityAsync(string cityid)
        {
            using var _context = _contextFactory.CreateDbContext();
            var city = await _context.mdt_city.FirstOrDefaultAsync(a => a.cityid == cityid);

            if (city == null)
            {
                return false;
            }

            _context.mdt_city.Remove(city);
            await _context.SaveChangesAsync();
            return true;

        }


        #endregion
        #region "District"
        public async Task<List<District>> GetDistrictAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_district
                .Include(c => c.City)
                .OrderByDescending(c => c.distid)
                .ToListAsync();
            return await result;
        }

        public async Task<List<District>> LoadDistrictAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_district
                                .Select(p => new District()
                                {
                                    distid = p.distid,
                                    distname = p.distname,
                                    City = p.City
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<string> GetDistrictByName(PickupRequest distName)
        {
            using var _context = _contextFactory.CreateDbContext();
            var dist = await _context.mdt_district.FirstOrDefaultAsync(p => p.distname == distName.distid);

            return dist?.distid ?? string.Empty;
        }

        public async Task<string> GetDistrictById(PickupRequest distId)
        {
            using var _context = _contextFactory.CreateDbContext();
            var dist = await _context.mdt_district.FirstOrDefaultAsync(p => p.distid == distId.distid);

            return dist?.distname ?? string.Empty;
        }


        public async Task<District?> GetDistrictByDistrictId(string distid)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_district.FirstOrDefaultAsync(a => a.distid == distid);
        }


        public Task<QueryData<District>> OnQueryDistrictAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_district.
                Include(c => c.City)
                .AsNoTracking()
                .ToList();

            var isSearched = false;
            if (options.SearchModel is District district)
            {
                if (!string.IsNullOrEmpty(district.distname))
                {
                    items = items.Where(item => item.distname?.Contains(district.distname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }
                if (!string.IsNullOrEmpty(district.distid))
                {
                    items = items.Where(item => item.distid?.Contains(district.distid, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(district.distname) || !string.IsNullOrEmpty(district.distid);
            }

            if (options.Searches.Any())
            {
                items = items.Where(options.Searches.GetFilterFunc<District>(FilterLogic.Or)).ToList();
            }

            var isFiltered = false;

            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<District>()).ToList();
                isFiltered = true;
            }

            var total = items.Count();

            return Task.FromResult(new QueryData<District>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });


        }


        public async Task<District> CreateDistrictAsync(District district)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.mdt_district.Add(district);
            await _context.SaveChangesAsync();
            return district;
        }


        public async Task<bool> SaveDistrictAsync(District data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    //data.createdby = "System";
                    //data.createddate = DateTime.Now;
                    _context.mdt_district.Add(data);
                }
                //else if (changedType == ItemChangedType.Update)
                //{
                //    _db.mdt_city.Update(data);
                //}
                else
                {
                    var existingEntity = await _context.mdt_district.FindAsync(data.distid);
                    if (existingEntity != null)
                    {
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;

                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }

        }

        public async Task<bool> UpdateDistrictAsync(string distid, District updatedDistrict)
        {
            using var _context = _contextFactory.CreateDbContext();

            var _district = await _context.mdt_district.FirstOrDefaultAsync(a => a.distid == distid);
            if (_district == null)
            {
                return false;
            }

            _district.distname = updatedDistrict.distname;
            _district.cityid = updatedDistrict.cityid;


            _context.Entry(_district).State = EntityState.Modified;

            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                System.Console.WriteLine($"SaveChanges affected rows: {affectedRows}");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in Update District Async: {ex.Message}");
                return false;
            }
        }





        public async Task<bool> DeleteDistrictAsync(string distid)
        {
            using var _context = _contextFactory.CreateDbContext();
            var data = await _context.mdt_district.FirstOrDefaultAsync(a => a.distid == distid);

            if (data == null)
            {
                return false;
            }

            _context.mdt_district.Remove(data);
            await _context.SaveChangesAsync();
            return true;

        }




        #endregion
        #region "Village"
        public async Task<List<Village>> GetVillageAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_village
                .Include(c => c.District)
                .OrderByDescending(c => c.villid)
                .ToListAsync();
            return await result;
        }

        public async Task<List<Village>> LoadVillageAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_village
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
            using var _context = _contextFactory.CreateDbContext();
            return _context.mdt_village.AsNoTracking().ToList();
        }

        public async Task<Village?> GetVillageByVillageId(string villid)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_village.FirstOrDefaultAsync(a => a.villid == villid);
        }


        public Task<QueryData<Village>> OnQueryVillageAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_village.
                Include(c => c.District)
                .AsNoTracking()
                .ToList();

            var isSearched = false;
            if (options.SearchModel is Village village)
            {
                if (!string.IsNullOrEmpty(village.villname))
                {
                    items = items.Where(item => item.villname?.Contains(village.villname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }
                if (!string.IsNullOrEmpty(village.villid))
                {
                    items = items.Where(item => item.villid?.Contains(village.villid, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(village.villname) || !string.IsNullOrEmpty(village.villid);
            }

            if (options.Searches.Any())
            {
                items = items.Where(options.Searches.GetFilterFunc<Village>(FilterLogic.Or)).ToList();
            }

            var isFiltered = false;

            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Village>()).ToList();
                isFiltered = true;
            }

            var total = items.Count();

            return Task.FromResult(new QueryData<Village>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });

        }


        public async Task<Village> CreateVillageAsync(Village village)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.mdt_village.Add(village);
            await _context.SaveChangesAsync();
            return village;
        }


        public async Task<bool> SaveVillageAsync(Village village, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    //data.createdby = "System";
                    //data.createddate = DateTime.Now;
                    _context.mdt_village.Add(village);
                }
                //else if (changedType == ItemChangedType.Update)
                //{
                //    _db.mdt_city.Update(data);
                //}
                else
                {
                    var existingEntity = await _context.mdt_village.FindAsync(village.villid);
                    if (existingEntity != null)
                    {
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    _context.Attach(village);
                    _context.Entry(village).State = EntityState.Modified;

                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }

        }

        public async Task<bool> UpdateVillageAsync(string villid, Village updatedVillage)
        {
            using var _context = _contextFactory.CreateDbContext();
            var _village = await _context.mdt_village.FirstOrDefaultAsync(a => a.villid == villid);
            if (_village == null)
            {
                return false;
            }

            _village.villname = updatedVillage.villname;
            _village.villid = updatedVillage.villid;
            _village.distid = updatedVillage.distid;


            _context.Entry(_village).State = EntityState.Modified;

            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in Update District Async: {ex.Message}");
                return false;
            }
        }




        public async Task<bool> DeleteVillageAsync(string villid)
        {
            using var _context = _contextFactory.CreateDbContext();
            var data = await _context.mdt_village.FirstOrDefaultAsync(a => a.villid == villid);

            if (data == null)
            {
                return false;
            }

            _context.mdt_village.Remove(data);
            await _context.SaveChangesAsync();
            return true;

        }





        #endregion
        #region "CIF"
        public async Task<List<CIF>> GetCifAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_cif
                .Include(c => c.Industry)
                .Include(c => c.Branch)
                .AsNoTracking()
                .OrderByDescending(c => c.cif)
                .ToListAsync();
        }

        public async Task<IEnumerable<CIF>> GetCifListAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_cif.ToListAsync();
        }


        public async Task<CIF?> GetCifByCIFAsync(string cif)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_cif.FirstOrDefaultAsync(a => a.cif == cif);
        }



        public Task<QueryData<CIF>> OnQueryCifAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_cif
                .Include(c => c.Industry)
                .Include(c => c.Branch)
                .AsNoTracking()
                .ToList();

            var isSearched = false;

            if (options.SearchModel is CIF cif)
            {
                if (!string.IsNullOrEmpty(cif.cif))
                {
                    items = items.Where(item => item.cif?.Contains(cif.cif, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(cif.cifname))
                {
                    items = items.Where(item => item.cifname?.Contains(cif.cifname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(cif.cif) || !string.IsNullOrEmpty(cif.cifname);
            }

            if (options.Searches.Any())
            {
                items = items.Where(options.Searches.GetFilterFunc<CIF>(FilterLogic.Or)).ToList();
            }

            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<CIF>()).ToList();
                isFiltered = true;
            }

            var total = items.Count;

            return Task.FromResult(new QueryData<CIF>
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSearch = isSearched
            });
        }

        public async Task<bool> CreateCifAsync(CIF data)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                _context.mdt_cif.Add(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in CreateCifAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateCifAsync(string cif, CIF updatedCIF)
        {
            using var _context = _contextFactory.CreateDbContext();
            var _cif = await _context.mdt_cif.FirstOrDefaultAsync(a => a.cif == cif);
            if (_cif == null)
            {
                return false;
            }

            _cif.cifname = updatedCIF.cifname;
            _cif.industryid = updatedCIF.industryid;
            _cif.branchid = updatedCIF.branchid;

            _context.Entry(_cif).State = EntityState.Modified;

            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                System.Console.WriteLine($"SaveChanges affected rows: {affectedRows}");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error saving changes: " + ex.Message);
                return false;
            }
        }

        public async Task<CIF> CreateCIFAsync(CIF cif)
        {
            using var _context = _contextFactory.CreateDbContext();
            string prefix = "CIF";
            string generatedCif = await GenerateUniqueCifAsync(prefix);
            cif.cif = generatedCif;
            _context.mdt_cif.Add(cif);
            await _context.SaveChangesAsync();
            return cif;
        }

        public async Task<string> GenerateUniqueCifAsync(string prefix)
        {
            using var _context = _contextFactory.CreateDbContext();
            int retryCount = 0;
            const int maxRetries = 5;
            while (retryCount < maxRetries)
            {
                var lastCif = await _context.mdt_cif.AsNoTracking()
                    .Where(c => c.cif.StartsWith(prefix))
                    .OrderByDescending(c => c.cif)
                    .FirstOrDefaultAsync();
                string newCif;
                if (lastCif == null)
                {
                    newCif = $"{prefix}001";
                }
                else
                {
                    string lastNumberId = lastCif.cif.Substring(prefix.Length);
                    if (!int.TryParse(lastNumberId, out int lastNumber))
                    {
                        throw new InvalidOperationException("Invalid CIF format in database");
                    }
                    if (lastNumber >= 999)
                    {
                        throw new InvalidOperationException("CIF number overflow. Cannot generate a new number");
                    }
                    newCif = $"{prefix}{(lastNumber + 1):D3}";
                }
                bool cifExists = await _context.mdt_cif.AsNoTracking()
                    .AnyAsync(c => c.cif == newCif);
                if (!cifExists)
                {
                    return newCif;
                }
                retryCount++;
            }
            throw new InvalidOperationException("Unable to generate a unique CIF after multiple attempts");
        }


        public async Task<bool> DeleteCIFAsync(string cif)
        {
            using var _context = _contextFactory.CreateDbContext();
            var data = await _context.mdt_cif.FirstOrDefaultAsync(a => a.cif == cif);

            if (data == null)
            {
                return false;
            }

            _context.mdt_cif.Remove(data);
            await _context.SaveChangesAsync();
            return true;

        }



        #endregion
        #region "Account"


        public async Task<IEnumerable<Account>> GetAllAccountAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_account
                .Include(a => a.Branch)
                .Include(a => a.CIF)
                .ToListAsync();
        }

        public async Task<(List<Account> Accounts, int TotalCount)> GetAccountsPagedAsync(int pageIndex, int pageSize)
        {
            using var _context = _contextFactory.CreateDbContext();

            var query = _context.mdt_account.Include(a => a.Branch).AsQueryable();

            var totalCount = await query.CountAsync();

            var accounts = await query
                .OrderBy(a => a.acctno) // Or any order you want
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (accounts, totalCount);
        }

        public Task<QueryData<Account>> OnQueryAccountAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_account
                .Include(c => c.Branch)
                .Include(c => c.CIF)
                .AsNoTracking()
                .ToList();

            var isSearched = false;

            if (options.SearchModel is Account account)
            {
                if (!string.IsNullOrEmpty(account.acctno))
                {
                    items = items.Where(item => item.acctno?.Contains(account.acctno, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(account.acctname))
                {
                    items = items.Where(item => item.acctname?.Contains(account.acctname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(account.acctno) || !string.IsNullOrEmpty(account.acctname);
            }

            if (options.Searches.Any())
            {
                items = items.Where(options.Searches.GetFilterFunc<Account>(FilterLogic.Or)).ToList();
            }

            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Account>()).ToList();
                isFiltered = true;
            }

            var total = items.Count;

            return Task.FromResult(new QueryData<Account>
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSearch = isSearched
            });
        }




        public async Task<Account?> GetAccountByAcctNoAsync(string acctno)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_account.FirstOrDefaultAsync(a => a.acctno == acctno);
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            using var _context = _contextFactory.CreateDbContext();
            string prefix = "NCS";
            string generatedAccountNo = await GenerateUniqueAccountAsync(prefix);
            account.acctno = generatedAccountNo;

            _context.mdt_account.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }


        public async Task<string> GenerateUniqueAccountAsync(string prefix)
        {
            using var _context = _contextFactory.CreateDbContext();
            int retryCount = 0;
            const int maxRetries = 5;

            while (retryCount < maxRetries)
            {
                var lastAccount = await _context.mdt_account.AsNoTracking()
                    .Where(a => a.acctno.StartsWith(prefix))
                    .OrderByDescending(a => a.acctno)
                    .FirstOrDefaultAsync();
                string newAcctNo;

                if (lastAccount == null)
                {
                    newAcctNo= $"{prefix}001";
                }
                else
                {
                    string lastNumberId = lastAccount.acctno.Substring(prefix.Length);
                    if (!int.TryParse(lastNumberId, out int lastNumber))
                    {
                        throw new InvalidOperationException("Invalid account number format in database");
                    }

                    if (lastNumber >= 999)
                    {
                        throw new InvalidOperationException("Account number overflow.Cannot generate a new number");
                    }

                    newAcctNo = $"{prefix}{(lastNumber+1):D3}";

                }

                bool acctNoExists = await _context.mdt_account.AsNoTracking()
                    .AnyAsync(a => a.acctno == newAcctNo);

                if (!acctNoExists)
                {
                    return newAcctNo;
                }

                retryCount++;

            }
            throw new InvalidOperationException("Unable to generate a unique account number after multiple attempts");

        }


        public async Task<bool> UpdateAccountAsync(string acctno, Account updatedAccount)
        {
            using var _context = _contextFactory.CreateDbContext();
            var account = await _context.mdt_account.FirstOrDefaultAsync(a => a.acctno == acctno);
            if (account == null)
            {
                return false;
            }
            account.acctname = updatedAccount.acctname;
            account.cif = updatedAccount.cif;
            account.branchid = updatedAccount.branchid;
            account.lob = updatedAccount.lob;
            account.costcenter = updatedAccount.costcenter;
            account.bankacctno = updatedAccount.bankacctno;
            account.bankacctname = updatedAccount.bankacctname;
            account.bankcode = updatedAccount.bankcode;
            account.frp = updatedAccount.frp;
            account.agreedate = updatedAccount.agreedate;
            account.agreeexpire = updatedAccount.agreeexpire;
            account.termofpayment = updatedAccount.termofpayment;
            account.creditlimit = updatedAccount.creditlimit;
            account.creditperiod = updatedAccount.creditperiod;
            account.iscod = updatedAccount.iscod;
            account.feecod = updatedAccount.feecod;
            account.isintl = updatedAccount.isintl;
            account.isnl = updatedAccount.isnl;
            account.discrates = updatedAccount.discrates;
            account.ppn = updatedAccount.ppn;
            account.mgmtfee = updatedAccount.mgmtfee;
            account.isrev = updatedAccount.isrev;
            account.istrace = updatedAccount.istrace;
            account.isvat = updatedAccount.isvat;
            account.vattype = updatedAccount.vattype;
            account.stampcosttype = updatedAccount.stampcosttype;
            //account.status = updatedAccount.status;
            account.modifieddate = System.DateTime.Now;
            account.modifier = updatedAccount.modifier;

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                System.Console.WriteLine($"SaveChanges affected rows: {affectedRows}");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error saving changes: " + ex.Message);
                return false;
            }

        }
        public async Task<bool> DeleteAccountAsync(string acctno)
        {
            using var _context = _contextFactory.CreateDbContext();
            var account = await _context.mdt_account.FirstOrDefaultAsync(a => a.acctno == acctno);

            if (account == null)
            {
                return false;
            }

            _context.mdt_account.Remove(account);
            await _context.SaveChangesAsync();
            return true;

        }


        #endregion
        #region "Industry"
        public async Task<List<Industry>> GetIndustryAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_industry
                .OrderByDescending(c => c.id)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }


        public async Task<IEnumerable<Industry>> GetAllIndustryAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_industry.ToListAsync();
        }




        public async Task<Industry?> GetIndustryByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_industry.FirstOrDefaultAsync(a => a.id == id);
        }
        public async Task<List<Industry>> LoadIndustryAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_industry
                                .Select(p => new Industry()
                                {
                                    id = p.id,
                                    industryname = p.industryname
                                })
                .ToListAsync();
            return await result;
        }

        public Task<QueryData<Industry>> OnQueryIndustryAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_industry.ToList();

            var isSearched = false;

            if (options.SearchModel is Industry industry)
            {
                if (!string.IsNullOrEmpty(industry.industryname))
                {
                    items = items.Where(item => item.industryname?.Contains(industry.industryname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }



                isSearched = !string.IsNullOrEmpty(industry.industryname);
            }

            if (options.Searches.Any())
            {
                items = items.Where(options.Searches.GetFilterFunc<Industry>(FilterLogic.Or)).ToList();
            }


            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Industry>()).ToList();
                isFiltered = true;
            }

            var total = items.Count();

            return Task.FromResult(new QueryData<Industry>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });



        }



        public async Task<bool> UpdateIndustryAsync(int _id, Industry updatedIndustry)
        {

            if (string.IsNullOrWhiteSpace(updatedIndustry.industryname))
            {
                return false;
            }


            using var _context = _contextFactory.CreateDbContext();
            var industry = await _context.mdt_industry.FirstOrDefaultAsync(a => a.id == _id);
            if (industry == null)
            {
                return false;
            }
            industry.industryname = updatedIndustry.industryname;
            industry.description = updatedIndustry.description;
            industry.flag = updatedIndustry.flag;


            _context.Entry(industry).State = EntityState.Modified;
            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }


        }


        public async Task<Industry> CreateIndustryAsync(Industry industry)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.mdt_industry.Add(industry);
            await _context.SaveChangesAsync();
            return industry;
        }



        public async Task<bool> DeleteIndustryByIdAsync(int _id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var industry = await _context.mdt_industry.FirstOrDefaultAsync(a => a.id == _id);

            if (industry == null)
            {
                return false;
            }

            _context.mdt_industry.Remove(industry);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion
        #region "Relation Code"

        public async Task<List<Relation>> GetRelationAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_relation
                .OrderByDescending(c => c.id)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public Task<QueryData<Relation>> OnQueryRelationAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_relation.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Relation model)
            {
                if (!string.IsNullOrEmpty(model.relationname))
                {
                    items = items.Where(item => item.relationname?.Contains(model.relationname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.relationcode))
                {
                    items = items.Where(item => item.relationcode?.Contains(model.relationcode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.relationname) || !string.IsNullOrEmpty(model.relationcode);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Relation>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Relation>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    //items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    items = invoker(items, options.SortName, options.SortOrder).ToList();
            //    isSorted = true;
            //}

            var total = items.Count();

            return Task.FromResult(new QueryData<Relation>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<Relation>> GetRelationComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_relation
                                .Select(p => new Relation()
                                {
                                    id = p.id,
                                    relationname = p.relationname,
                                    relationcode = p.relationcode,
                                    remarks = p.remarks,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> SaveRelationAsync(Relation data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_relation.Add(data);
                }
                else
                {
                    var existingEntity = await _context.mdt_relation.FindAsync(data.id);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> DeleteRelationByIDAsync(IEnumerable<Relation> relations)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                foreach (var relation in relations)
                {
                    var existing = await _context.mdt_relation.FindAsync(relation.id);
                    if (existing != null)
                    {
                        _context.mdt_relation.Remove(existing);
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion
        #region "Reason UN"

        public async Task<List<ReasonUN>> GetReasonAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_reasonun
                .OrderByDescending(c => c.id)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public Task<QueryData<ReasonUN>> OnQueryReasonAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_reasonun.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is ReasonUN model)
            {
                if (!string.IsNullOrEmpty(model.reasonname))
                {
                    items = items.Where(item => item.reasonname?.Contains(model.reasonname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.reasoncode))
                {
                    items = items.Where(item => item.reasoncode?.Contains(model.reasoncode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.reasonname) || !string.IsNullOrEmpty(model.reasoncode);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<ReasonUN>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<ReasonUN>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    //items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    items = invoker(items, options.SortName, options.SortOrder).ToList();
            //    isSorted = true;
            //}

            var total = items.Count();

            return Task.FromResult(new QueryData<ReasonUN>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<ReasonUN>> GetReasonComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_reasonun
                                .Select(p => new ReasonUN()
                                {
                                    id = p.id,
                                    reasonname = p.reasonname,
                                    reasoncode = p.reasoncode,
                                    remarks = p.remarks,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> SaveReasonAsync(ReasonUN data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_reasonun.Add(data);
                }
                else
                {
                    var existingEntity = await _context.mdt_reasonun.FindAsync(data.id);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> DeleteReasonByIDAsync(IEnumerable<ReasonUN> reasons)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                foreach (var reason in reasons)
                {
                    var existing = await _context.mdt_reasonun.FindAsync(reason.id);
                    if (existing != null)
                    {
                        _context.mdt_reasonun.Remove(existing);
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion
        #region "Cost Component"
        public async Task<List<CostComponent>> GetCostComponentAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_costcomponent
                .OrderByDescending(c => c.id)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public async Task<IEnumerable<CostComponent>> GetAllCostComponentAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_costcomponent.ToListAsync();
        }



        public async Task<CostComponent?> GetCostComponentByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_costcomponent.FirstOrDefaultAsync(a => a.id == id);
        }



        public Task<QueryData<CostComponent>> OnQueryCostComponentAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_costcomponent.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is CostComponent model)
            {
                if (!string.IsNullOrEmpty(model.componentname))
                {
                    items = items.Where(item => item.componentname?.Contains(model.componentname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.type))
                {
                    items = items.Where(item => item.type?.Contains(model.type, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.componentname) || !string.IsNullOrEmpty(model.type);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<CostComponent>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<CostComponent>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    //items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    items = invoker(items, options.SortName, options.SortOrder).ToList();
            //    isSorted = true;
            //}

            var total = items.Count();

            return Task.FromResult(new QueryData<CostComponent>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<CostComponent>> GetCostComponentComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_costcomponent
                                .Select(p => new CostComponent()
                                {
                                    id = p.id,
                                    componentname = p.componentname,
                                    type = p.type,
                                    description = p.description,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> UpdateCostComponentAsync(int _id, CostComponent updatedCostComponent)
        {
            using var _context = _contextFactory.CreateDbContext();
            var costcomponent = await _context.mdt_costcomponent.FirstOrDefaultAsync(a => a.id == _id);
            if (costcomponent == null)
            {
                return false;
            }
            costcomponent.componentname = updatedCostComponent.componentname;
            costcomponent.type = updatedCostComponent.type;
            costcomponent.description = updatedCostComponent.description;

            _context.Entry(costcomponent).State = EntityState.Modified;
            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                System.Console.WriteLine($"SaveChanges affected rows: {affectedRows}");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error saving changes: " + ex.Message);
                return false;
            }

        }

        public async Task<CostComponent> CreateCostComponentAsync(CostComponent costcomponent)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.mdt_costcomponent.Add(costcomponent);
            await _context.SaveChangesAsync();
            return costcomponent;
        }

        public async Task<bool> SaveCostComponentAsync(CostComponent data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_costcomponent.Add(data);
                }
                else
                {
                    var existingEntity = await _context.mdt_costcomponent.FindAsync(data.id);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> DeleteCostComponentByIdAsync(int _id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var costcomponent = await _context.mdt_costcomponent.FirstOrDefaultAsync(a => a.id == _id);

            if (costcomponent == null)
            {
                return false;
            }

            _context.mdt_costcomponent.Remove(costcomponent);
            await _context.SaveChangesAsync();
            return true;
        }

        #endregion
        #region "Service Code"
        public async Task<List<Service>> GetServiceAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_service
                .OrderByDescending(c => c.servicename)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public Task<QueryData<Service>> OnQueryServiceAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_service.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Service model)
            {
                if (!string.IsNullOrEmpty(model.servicename))
                {
                    items = items.Where(item => item.servicename?.Contains(model.servicename, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.servicecode))
                {
                    items = items.Where(item => item.servicecode?.Contains(model.servicecode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.servicename) || !string.IsNullOrEmpty(model.servicecode);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Service>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Service>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    //items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    items = invoker(items, options.SortName, options.SortOrder).ToList();
            //    isSorted = true;
            //}

            var total = items.Count();

            return Task.FromResult(new QueryData<Service>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<Service>> GetServiceComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_service
                                .Select(p => new Service()
                                {
                                    servicename = p.servicename,
                                    servicecode = p.servicecode,
                                    remarks = p.remarks,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> SaveServiceAsync(Service data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_service.Add(data);
                }
                else
                {
                    var existingEntity = await _context.mdt_service.FindAsync(data.servicename);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> DeleteServiceByServiceNameAsync(IEnumerable<Service> services)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                foreach (var service in services)
                {
                    var existing = await _context.mdt_service.FindAsync(service.servicename);
                    if (existing != null)
                    {
                        _context.mdt_service.Remove(existing);
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
        #region "Packing Type"
        public async Task<List<PackingType>> GetPackingTypeAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_packingtype
                .OrderBy(c => c.packingcode)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public Task<QueryData<PackingType>> OnQueryPackingTypeAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_packingtype.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is PackingType model)
            {
                if (!string.IsNullOrEmpty(model.packingcode))
                {
                    items = items.Where(item => item.packingcode?.Contains(model.packingcode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.packingname))
                {
                    items = items.Where(item => item.packingname?.Contains(model.packingname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.packingcode) || !string.IsNullOrEmpty(model.packingname);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<PackingType>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<PackingType>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    //items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    items = invoker(items, options.SortName, options.SortOrder).ToList();
            //    isSorted = true;
            //}

            var total = items.Count();

            return Task.FromResult(new QueryData<PackingType>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<PackingType>> GetPackingTypeComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_packingtype
                                .Select(p => new PackingType()
                                {
                                    packingcode = p.packingcode,
                                    packingname = p.packingname,
                                    remarks = p.remarks,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> SavePackingTypeAsync(PackingType data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_packingtype.Add(data);
                }
                else
                {
                    var existingEntity = await _context.mdt_packingtype.FindAsync(data.packingcode);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> DeletePackingTypeByPackingCodeAsync(IEnumerable<PackingType> packingTypes)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                foreach (var packingType in packingTypes)
                {
                    var existing = await _context.mdt_packingtype.FindAsync(packingType.packingcode);
                    if (existing != null)
                    {
                        _context.mdt_packingtype.Remove(existing);
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }



        #endregion
        #region "CityINTL"
        public async Task<List<CityIntl>> GetCityIntlAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_cityintl
                .OrderByDescending(c => c.id)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public async Task<IEnumerable<CityIntl>> GetAllCityIntlAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_cityintl.ToListAsync();
        }



        public async Task<CityIntl?> GetCityIntlByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_cityintl.FirstOrDefaultAsync(a => a.id == id);
        }



        public Task<QueryData<CityIntl>> OnQueryCityIntlAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_cityintl.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is CityIntl model)
            {
                if (!string.IsNullOrEmpty(model.countrycode))
                {
                    items = items.Where(item => item.countrycode?.Contains(model.countrycode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.citycode))
                {
                    items = items.Where(item => item.citycode?.Contains(model.citycode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.countrycode) || !string.IsNullOrEmpty(model.citycode);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<CityIntl>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<CityIntl>()).ToList();
                isFiltered = true;
            }


            var total = items.Count();

            return Task.FromResult(new QueryData<CityIntl>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<CityIntl>> GetCityIntlComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_cityintl
                                .Select(p => new CityIntl()
                                {
                                    id = p.id,
                                    cityname = p.cityname,
                                    citycode = p.citycode,
                                    airport = p.airport,
                                    countrycode = p.countrycode,
                                    region = p.region,
                                    zone3pl1 = p.zone3pl1,
                                    zone3pl2 = p.zone3pl2,
                                    zone3pl3 = p.zone3pl3,
                                    disc3pl1 = p.disc3pl1,
                                    disc3pl2 = p.disc3pl2,
                                    disc3pl3 = p.disc3pl3
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> UpdateCityIntlAsync(int _id, CityIntl updatedCityIntl)
        {
            using var _context = _contextFactory.CreateDbContext();
            var cityintl = await _context.mdt_cityintl.FirstOrDefaultAsync(a => a.id == _id);
            if (cityintl == null)
            {
                return false;
            }
            cityintl.cityname = updatedCityIntl.cityname;
            cityintl.citycode = updatedCityIntl.citycode;
            cityintl.airport = updatedCityIntl.airport;
            cityintl.countrycode = updatedCityIntl.countrycode;
            

            _context.Entry(cityintl).State = EntityState.Modified;
            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                System.Console.WriteLine($"SaveChanges affected rows: {affectedRows}");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error saving changes: " + ex.Message);
                return false;
            }

        }

        public async Task<CityIntl> CreateCityIntlAsync(CityIntl cityintl)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.mdt_cityintl.Add(cityintl);
            await _context.SaveChangesAsync();
            return cityintl;
        }

        public async Task<bool> SaveCityIntlAsync(CityIntl data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_cityintl.Add(data);
                }
                else
                {
                    var existingEntity = await _context.mdt_cityintl.FindAsync(data.id);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> DeleteCityIntlByIdAsync(int _id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var cityintl = await _context.mdt_cityintl.FirstOrDefaultAsync(a => a.id == _id);

            if (cityintl == null)
            {
                return false;
            }

            _context.mdt_cityintl.Remove(cityintl);
            await _context.SaveChangesAsync();
            return true;
        }


        #endregion
        #region "Packing Size"
        public async Task<List<PackingSize>> GetPackingSizeAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_packingsize
                .OrderBy(c => c.sizecode)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public Task<QueryData<PackingSize>> OnQueryPackingSizeAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_packingsize.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is PackingSize model)
            {
                if (!string.IsNullOrEmpty(model.sizecode))
                {
                    items = items.Where(item => item.sizecode?.Contains(model.sizecode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.sizename))
                {
                    items = items.Where(item => item.sizename?.Contains(model.sizename, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.sizecode) || !string.IsNullOrEmpty(model.sizename);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<PackingSize>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<PackingSize>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    //items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    items = invoker(items, options.SortName, options.SortOrder).ToList();
            //    isSorted = true;
            //}

            var total = items.Count();

            return Task.FromResult(new QueryData<PackingSize>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<PackingSize>> GetPackingSizeComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_packingsize
                                .Select(p => new PackingSize()
                                {
                                    sizecode = p.sizecode,
                                    sizename = p.sizename,
                                    remarks = p.remarks,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> SavePackingSizeAsync(PackingSize data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_packingsize.Add(data);
                }
                else
                {
                    var existingEntity = await _context.mdt_packingsize.FindAsync(data.sizecode);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> DeletePackingSizeBySizeCodeAsync(IEnumerable<PackingSize> packingsizes)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                foreach (var packingsize in packingsizes)
                {
                    var existing = await _context.mdt_packingsize.FindAsync(packingsize.sizecode);
                    if (existing != null)
                    {
                        _context.mdt_packingsize.Remove(existing);
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion
        #region "Packing Price"

        public async Task<List<PackingPrice>> GetPackingPriceAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = await _context.mdt_packingprice
                .OrderByDescending(c => c.packingcode)
                .Include(c => c.PackingType)
                .Include(c => c.PackingSize)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }


        public async Task<IEnumerable<PackingPrice>> GetAllPackingPriceAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_packingprice.ToListAsync();
        }



        public async Task<PackingPrice?> GetPackingPriceByIdAsync(string packingcode, string sizecode)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_packingprice
                .FirstOrDefaultAsync(a => a.packingcode == packingcode && a.sizecode == sizecode);
        }




        public Task<QueryData<PackingPrice>> OnQueryPackingPriceAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_packingprice.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is PackingPrice model)
            {
                if (!string.IsNullOrEmpty(model.packingcode))
                {
                    items = items.Where(item => item.packingcode?.Contains(model.packingcode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.sizecode))
                {
                    items = items.Where(item => item.sizecode?.Contains(model.sizecode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.packingcode) || !string.IsNullOrEmpty(model.sizecode);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<PackingPrice>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<PackingPrice>()).ToList();
                isFiltered = true;
            }


            var total = items.Count();

            return Task.FromResult(new QueryData<PackingPrice>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<PackingPrice>> GetPackingPriceComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_packingprice
                                .Select(p => new PackingPrice()
                                {
                                    packingcode = p.packingcode,
                                    sizecode = p.sizecode,
                                    price = p.price,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> UpdatePackingPriceAsync(string packingcode, string sizecode, PackingPrice updatedPackingPrice)
        {
            using var _context = _contextFactory.CreateDbContext();
            var packingprice = await _context.mdt_packingprice
                .FirstOrDefaultAsync(a => a.packingcode == packingcode && a.sizecode == sizecode);
            if (packingprice == null)
            {
                return false;
            }
            packingprice.price = updatedPackingPrice.price;

            _context.Entry(packingprice).State = EntityState.Modified;
            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }


        public async Task<PackingPrice> CreatePackingPriceAsync(PackingPrice packingPrice)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.mdt_packingprice.Add(packingPrice);
            await _context.SaveChangesAsync();
            return packingPrice ;
        }

        public async Task SavePackingPricesAsync(List<PackingPrice> updatedPrices)
        {
            using var _context = _contextFactory.CreateDbContext();

            foreach (var price in updatedPrices)
            {
                var existing = await _context.mdt_packingprice
                    .FirstOrDefaultAsync(pp => pp.packingcode == price.packingcode && pp.sizecode == price.sizecode);
                if (existing != null)
                {
                    existing.price = price.price;
                    _context.Update(existing);
                }
                else
                {
                    _context.Add(price);
                }
            }

            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeletePackingPrizeByPackingCodeAsync(string packingcode)
        {
            using var _context = _contextFactory.CreateDbContext();
            var packingprice = await _context.mdt_packingprice.FirstOrDefaultAsync(a => a.packingcode == packingcode);

            if (packingprice == null)
            {
                return false;
            }

            _context.mdt_packingprice.Remove(packingprice);
            await _context.SaveChangesAsync();
            return true;
        }


        #endregion


        #region "Bank"

        public async Task<List<Bank>> GetBankAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_bank
                .OrderBy(c => c.id)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public Task<QueryData<Bank>> OnQueryBankAsync(QueryPageOptions options)
        {
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_bank.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Bank model)
            {
                if (!string.IsNullOrEmpty(model.bankname))
                {
                    items = items.Where(item => item.bankname?.Contains(model.bankname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.bankcode))
                {
                    items = items.Where(item => item.bankcode?.Contains(model.bankcode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.bankname) || !string.IsNullOrEmpty(model.bankcode);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Bank>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Bank>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    //items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    items = invoker(items, options.SortName, options.SortOrder).ToList();
            //    isSorted = true;
            //}

            var total = items.Count();

            return Task.FromResult(new QueryData<Bank>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<Bank>> GetBankComboAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.mdt_bank
                                .Select(p => new Bank()
                                {
                                    id = p.id,
                                    bankname = p.bankname,
                                    bankcode = p.bankcode,
                                    swiftcode = p.swiftcode,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> SaveBankAsync(Bank data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_bank.Add(data);
                }
                else
                {
                    var existingEntity = await _context.mdt_reasonun.FindAsync(data.id);

                    if (existingEntity != null)
                    {
                        
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                   
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public async Task<bool> DeleteBankByIDAsync(IEnumerable<Bank> banks)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                foreach (var bank in banks)
                {
                    var existing = await _context.mdt_bank.FindAsync(bank.id);
                    if (existing != null)
                    {
                        _context.mdt_bank.Remove(existing);
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }



        #endregion



    }
}
