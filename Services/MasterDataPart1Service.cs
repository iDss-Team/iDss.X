
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using System.Linq;

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
            var result = await  _context.mdt_city
                .Include(c => c.Province)
                .AsNoTracking()
                .OrderByDescending(c => c.cityid)
                .ToListAsync();
            
            foreach(var item in result)
            {
                System.Console.WriteLine($"City : {item.cityname}, Province : {(item.Province != null ? item.Province.provname : "NULL")}");
            }

            return result;
        }


        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_city.ToListAsync();
        }

        public Task<QueryData<City>>OnQueryCityAsync(QueryPageOptions options){
            using var _context = _contextFactory.CreateDbContext();
            var items = _context.mdt_city.ToList();

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
                items = items.Where(options.Searches.GetFilterFunc<City>(FilterLogic.Or)).ToList();
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
                // Handle exception
                return false;
            }

        }

        public async Task<bool> UpdateCityAsync(City data)
        {
            using var _context = _contextFactory.CreateDbContext();
            bool result;
            try
            {
                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                System.Console.WriteLine($"Error in UpdateCityAsync: {ex.Message}");
                result = false;
            }
            return result;
        }




        public async Task<bool> DeleteCityByIDAsync(IEnumerable<City> cities)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                var tasks = cities.Select(async city =>
                {
                    var existingEntity = await _context.mdt_city.FindAsync(city.cityid);
                    if (existingEntity != null)
                    {
                        _context.mdt_city.Remove(existingEntity);
                    }
                });
                await Task.WhenAll(tasks); // Delete cities concurrently
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in DeleteCityByIDAsync: {ex.Message}");
                return false;
            }
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

        public async Task<bool> UpdateCifAsync(CIF data)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in UpdateCifAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SaveCifAsync(CIF data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    _context.mdt_cif.Add(data);
                }
                else
                {
                    var existing = await _context.mdt_cif.FindAsync(data.cif);
                    if (existing != null)
                    {
                        _context.Entry(existing).State = EntityState.Detached;
                    }

                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in SaveCifAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteCifByIDAsync(IEnumerable<CIF> cifs)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                var tasks = cifs.Select(async cif =>
                {
                    var entity = await _context.mdt_cif.FindAsync(cif.cif);
                    if (entity != null)
                    {
                        _context.mdt_cif.Remove(entity);
                    }
                });

                await Task.WhenAll(tasks);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error in DeleteCifByIDAsync: {ex.Message}");
                return false;
            }
        }




        #endregion

        #region "Account"


        public async Task<IEnumerable<Account>> GetAllAccountAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.mdt_account
                .Include(a => a.Branch)
                .ToListAsync();
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
            account.isrev = updatedAccount.isrev;
            account.istrace = updatedAccount.istrace;
            //account.status = updatedAccount.status;
            account.modifieddate = System.DateTime.Now;
            account.modifier = updatedAccount.modifier;

            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> DeleteAccountAsync(IEnumerable<Account> accountItems)
        {
            using var _context = _contextFactory.CreateDbContext();
            bool allDeleted = true;

            foreach (var account in accountItems)
            {
                var dbAccount = await _context.mdt_account.FirstOrDefaultAsync(a => a.acctno == account.acctno);
                if (dbAccount != null)
                {
                    _context.mdt_account.Remove(dbAccount);
                }
                else
                {
                    allDeleted = false; // Something was not found
                }
            }

            await _context.SaveChangesAsync();
            return allDeleted;
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




        public async Task<bool> SaveIndustryAsync(Industry data, ItemChangedType changedType)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    //data.createdby = "System";
                    //data.createddate = DateTime.Now;
                    _context.mdt_industry.Add(data);
                }
                //else if (changedType == ItemChangedType.Update)
                //{
                //    _db.mdt_city.Update(data);
                //}
                else
                {
                    var existingEntity = await _context.mdt_industry.FindAsync(data.id);
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


        public async Task<bool> DeleteIndustryByIDAsync(IEnumerable<Industry> industries)
        {
            using var _context = _contextFactory.CreateDbContext();
            try
            {
                foreach (var industry in industries)
                {
                    var existingEntity = await _context.mdt_industry.FindAsync(industry.id);
                    if (existingEntity != null)
                    {
                        _context.mdt_industry.Remove(existingEntity);
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


    }



}
