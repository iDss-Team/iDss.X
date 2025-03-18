
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;

namespace iDss.X.Services
{
    public class MasterDataServices
    {
        private readonly AppDbContext _db;

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<TModel>, string, SortOrder, IEnumerable<TModel>>> SortLambdaCache = new();

        public MasterDataServices(AppDbContext context)
        {
            _db = context;
        }

        #region "Checkpoint"
        public async Task<List<Checkpoint>> GetCheckpointAsync()
        {
            var result = _db.mdt_checkpoint
                .OrderByDescending(c => c.createddate)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public Task<QueryData<Checkpoint>> OnQueryAsync(QueryPageOptions options)
        {
            var items = _db.mdt_checkpoint.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Checkpoint model)
            {
                if (!string.IsNullOrEmpty(model.cpcode))
                {
                    items = items.Where(item => item.cpcode?.Contains(model.cpcode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.cpname))
                {
                    items = items.Where(item => item.cpname?.Contains(model.cpname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.cpcode) || !string.IsNullOrEmpty(model.cpname);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Checkpoint>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Checkpoint>()).ToList();
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

            return Task.FromResult(new QueryData<Checkpoint>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<Checkpoint>> GetCheckpointComboAsync()
        {
            var result = _db.mdt_checkpoint
                                .Select(p => new Checkpoint()
                                {
                                    cpcode = p.cpcode,
                                    cpname = p.cpname,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<bool> SaveCheckpointAsync(Checkpoint data, ItemChangedType changedType)
        {
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    data.createdby = "user.login"; //ganti dengan username by session login
                    data.createddate = DateTime.Now.ToUniversalTime();
                    _db.mdt_checkpoint.Add(data);
                }
                else 
                {
                    var existingEntity = await _db.mdt_checkpoint.FindAsync(data.cpcode);

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

        public async Task<bool> DeleteCheckpointByIDAsync(IEnumerable<Checkpoint> checkpoints)
        {
            try
            {
                foreach (var checkpoint in checkpoints)
                {
                    var existing = await _db.mdt_checkpoint.FindAsync(checkpoint.cpcode);
                    if (existing != null)
                    {
                        _db.mdt_checkpoint.Remove(existing);
                    }
                }

                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region "Branch"
        public async Task<List<Branch>> GetbranchAsync()
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
            var items = await GetbranchAsync();


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

        public async Task<List<Branch>> GetBranchComboAsync()
        {
            var result = _db.mdt_branch
                                .Select(p => new Branch()
                                {
                                    branchcode = p.branchcode,
                                    branchname = p.branchname,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<Branch> GetBranchByIDAsync(Guid id)
        {
            var result = _db.mdt_branch.FindAsync(id);
            return await result;
        }

        public async Task<bool> CreateBranchAsync(Branch data, ItemChangedType changedType)
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
        public async Task<string> UpdateBranchAsync(Branch data)
        {
            string result;
            try
            {
                _db.Entry(data).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                result = "ok";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public async Task<bool> DeleteBranchByIDAsync(IEnumerable<Branch> branchs)
        {
            try
            {
                foreach (var branch in branchs)
                {
                    var existing = await _db.mdt_checkpoint.FindAsync(branch.branchid);
                    if (existing != null)
                    {
                        _db.mdt_checkpoint.Remove(existing);
                    }
                }

                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region "Counter"

        #endregion

        #region "Agent"

        #endregion

        #region "CIF"

        #endregion

        #region "Account"

        #endregion

        #region "Courier"

        #endregion
    }

    internal class TModel
    {
    }
}
