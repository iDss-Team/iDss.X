
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;

namespace iDss.X.Services
{
    public class MasterDataPart3Service
    {
        private readonly AppDbContext _db;

        public MasterDataPart3Service(AppDbContext context)
        {
            _db = context;
        }

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        //private static readonly ConcurrentDictionary<Type, Func<IEnumerable<TModel>, string, SortOrder, IEnumerable<TModel>>> SortLambdaCache = new();

        #region "Branch"
        public async Task<List<Branch>> GetBranchAsync()
        {
            var result = _db.mdt_branch
                .Include(c => c.Village)
                .OrderByDescending(c => c.createddate)
                .ToListAsync();
            return await result;
        }

        public async Task<QueryData<Branch>> OnQueryBranchAsync(QueryPageOptions options)
        {
            //var items = _db.mdt_branch.ToList();
            // Ambil data dari database
            var items = await GetBranchAsync();


            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Branch model)
            {
                if (!string.IsNullOrEmpty(model.branchcode))
                {
                    items = items.Where(item => item.branchcode?.Contains(model.branchcode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.branchname))
                {
                    items = items.Where(item => item.branchname?.Contains(model.branchname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.branchcode) || !string.IsNullOrEmpty(model.branchcode);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Branch>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Branch>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    isSorted = true;
            //}

            var total = items.Count();

            return await Task.FromResult(new QueryData<Branch>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<Branch>> LoadBranchAsync()
        {
            var result = _db.mdt_branch
                                .Select(p => new Branch()
                                {
                                    branchid = p.branchid,
                                    branchname = p.branchname,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<Branch> GetBranchByIDAsync(int id)
        {
            var result = _db.mdt_branch.FindAsync(id);
            return await result;
        }

        public async Task<Branch> GetBranchByBranchIdAsync(int id)
        {
            var result = _db.mdt_branch.FirstOrDefaultAsync(p => p.branchid == id);
            return await result;
        }

        public async Task<bool> CreateBranchAsync(Branch data)
        {
            bool result;
            try
            {
                data.createddate = DateTime.Now.ToUniversalTime();
                _db.mdt_branch.Add(data);
                await _db.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> SaveBranchAsync(Branch data, ItemChangedType changedType)
        {
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    data.createdby = "user.login"; //ganti dengan username by session login
                    data.createddate = DateTime.Now.ToUniversalTime();
                    _db.mdt_branch.Add(data);
                }
                else
                {
                    var existingEntity = await _db.mdt_branch.FindAsync(data.branchid);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _db.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _db.Attach(data);
                    _db.Entry(data).State = EntityState.Modified;
                }

                await _db.SaveChangesAsync();
                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> UpdateBranchAsync(Branch data)
        {
            bool result;
            try
            {
                _db.Entry(data).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteBranchByIDAsync(int id)
        {
            bool result;
            try
            {
                var affectedRows = await _db.mdt_branch.Where(x => x.branchid.Equals(id)).ExecuteDeleteAsync();
                result = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("23503"))
                {
                    //msg = "Cannot delete: This record is linked to other data already.";
                    result = false;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        #endregion

        #region "Counter"
        public async Task<List<Counter>> GetCounterAsync()
        {
            var result = _db.mdt_counter
                .Include(c => c.Village)
                .Include(b => b.Branch)
                .OrderByDescending(c => c.createddate)
                .ToListAsync();
            return await result;
        }

        public async Task<QueryData<Counter>> OnQueryCounterAsync(QueryPageOptions options)
        {
            //var items = _db.mdt_counter.ToList();
            // Ambil data dari database
            var items = await GetCounterAsync();


            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Counter model)
            {
                if (!string.IsNullOrEmpty(model.countercode))
                {
                    items = items.Where(item => item.countercode?.Contains(model.countercode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.countername))
                {
                    items = items.Where(item => item.countername?.Contains(model.countername, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.countercode) || !string.IsNullOrEmpty(model.countername);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Counter>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Counter>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    isSorted = true;
            //}

            var total = items.Count();

            return await Task.FromResult(new QueryData<Counter>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<Counter> GetCounterByIDAsync(int id)
        {
            var result = _db.mdt_counter.FindAsync(id);
            return await result;
        }

        public async Task<bool> CreateCounterAsync(Counter data)
        {
            bool result;
            try
            {
                data.createddate = DateTime.Now.ToUniversalTime();
                _db.mdt_counter.Add(data);
                await _db.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> UpdateCounterAsync(Counter data)
        {
            bool result;
            try
            {
                _db.Entry(data).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteCounterByIDAsync(int id)
        {
            bool result;
            try
            {
                var affectedRows = await _db.mdt_counter.Where(x => x.counterid.Equals(id)).ExecuteDeleteAsync();
                result = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("23503"))
                {
                    //msg = "Cannot delete: This record is linked to other data already.";
                    result = false;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        #endregion

        #region "Agent"
        public async Task<List<Agent>> GetAgentAsync()
        {
            var result = _db.mdt_agent
                .Include(c => c.Village)
                .Include(b => b.Branch)
                .OrderByDescending(c => c.createddate)
                .ToListAsync();
            return await result;
        }

        public async Task<QueryData<Agent>> OnQueryAgentAsync(QueryPageOptions options)
        {
            //var items = _db.mdt_agent.ToList();
            // Ambil data dari database
            var items = await GetAgentAsync();


            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Agent model)
            {
                if (!string.IsNullOrEmpty(model.agentcode))
                {
                    items = items.Where(item => item.agentcode?.Contains(model.agentcode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.agentname))
                {
                    items = items.Where(item => item.agentname?.Contains(model.agentname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.agentcode) || !string.IsNullOrEmpty(model.agentname);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Agent>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Agent>()).ToList();
                isFiltered = true;
            }

            //// Pengurutan
            //var isSorted = false;
            //if (!string.IsNullOrEmpty(options.SortName))
            //{
            //    // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
            //    var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
            //    items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
            //    isSorted = true;
            //}

            var total = items.Count();

            return await Task.FromResult(new QueryData<Agent>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<Agent> GetAgentByIDAsync(int id)
        {
            var result = _db.mdt_agent.FindAsync(id);
            return await result;
        }

        public async Task<bool> CreateAgentAsync(Agent data)
        {
            bool result;
            try
            {
                data.createddate = DateTime.Now.ToUniversalTime();
                _db.mdt_agent.Add(data);
                await _db.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> UpdateAgentAsync(Agent data)
        {
            bool result;
            try
            {
                _db.Entry(data).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteAgentByIDAsync(int id)
        {
            bool result;
            try
            {
                var affectedRows = await _db.mdt_agent.Where(x => x.agentid.Equals(id)).ExecuteDeleteAsync();
                result = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("23503"))
                {
                    //msg = "Cannot delete: This record is linked to other data already.";
                    result = false;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        #endregion
    }
}
