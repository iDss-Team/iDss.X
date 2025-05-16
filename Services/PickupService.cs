
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.Internal;

namespace iDss.X.Services
{
    public class PickupService
    {
        private readonly AppDbContext _db;

        public PickupService(AppDbContext context)
        {
            _db = context;
        }

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        #region "Entry Data Pickup"
        public async Task<List<PickupRequest>> GetPickupRequestAsync()
        {
            var result = _db.pum_pickuprequest
                .Include(c => c.Branch)
                .Include(c => c.District)
                .AsNoTracking()
                .OrderByDescending(c => c.createddate)
                .ToListAsync();
            return await result;
        }

        public async Task<QueryData<PickupRequest>> OnQueryPickupRequestAsync(QueryPageOptions options)
        {
            var items = await GetPickupRequestAsync();

            var isSearched = false;

            if (options.SearchModel is PickupRequest model)
            {
                if (!string.IsNullOrEmpty(model.pickupno))
                {
                    items = items.Where(item => item.pickupno?.Contains(model.pickupno, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.pickuptype))
                {
                    items = items.Where(item => item.pickuptype?.Contains(model.pickuptype, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.pickupno) || !string.IsNullOrEmpty(model.pickupno);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<PickupRequest>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<PickupRequest>()).ToList();
                isFiltered = true;
            }

            var total = items.Count();

            return await Task.FromResult(new QueryData<PickupRequest>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                //IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        public async Task<List<PickupRequest>> LoadPickupRequestAsync()
        {
            var result = _db.pum_pickuprequest
                                .Select(p => new PickupRequest()
                                {
                                    pickupno = p.pickupno,
                                    pickuptype = p.pickuptype,
                                })
                .ToListAsync();
            return await result;
        }

        public async Task<PickupRequest> GetPickupRequestByIDAsync(Guid id)
        {
            var result = _db.pum_pickuprequest.FindAsync(id);
            return await result;
        }

        public async Task<string?> GeneratePickupNoAsync()
        {
            var today = DateTime.UtcNow.Date;
            int countToday = await _db.pum_pickuprequest
                .CountAsync(p => p.createddate >= today && p.createddate < today.AddDays(1));

            if (countToday >= 9999)
                return null; // Melebihi batas per hari

            string datePart = DateTime.UtcNow.ToString("yyMMdd");
            string serialPart = (countToday + 1).ToString("D4");

            return datePart + serialPart;
        }


        public async Task<bool> CreatePickupRequestAsync(PickupRequest data)
        {
            bool result;
            try
            {
                data.createddate = DateTime.Now.ToUniversalTime();
                _db.pum_pickuprequest.Add(data);
                await _db.SaveChangesAsync();

                var status = new PickupStatusPool
                {
                    pickupno = data.pickupno,
                    pickupstatus = "request pickup"
                };
                _db.pum_pickupstatuspool.Add(status);
                await _db.SaveChangesAsync();

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<PickupRequest> GetPickupRequestByPickno(string pickno)
        {
            return await _db.pum_pickuprequest.FirstOrDefaultAsync(p => p.pickupno == pickno);
        }

        public async Task<bool> SavePickupRequestAsync(PickupRequest data, ItemChangedType changedType)
        {
            try
            {
                if (changedType == ItemChangedType.Add)
                {
                    data.createdby = "user.login"; //ganti dengan username by session login
                    data.createddate = DateTime.Now.ToUniversalTime();
                    _db.pum_pickuprequest.Add(data);
                }
                else
                {
                    var existingEntity = await _db.pum_pickuprequest.FindAsync(data.id);

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

        public async Task<bool> UpdatePickupRequestAsync(PickupRequest data)
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

        public async Task<bool> DeletePickupRequestByIDAsync(IEnumerable<PickupRequest> pickupRequests)
        {
            try
            {
                foreach (var pickupRequest in pickupRequests)
                {
                    var existing = await _db.pum_pickuprequest.FindAsync(pickupRequest.pickupno);
                    if (existing != null)
                    {
                        _db.pum_pickuprequest.Remove(existing);
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

        public async Task<string> DeletePickupByPickno(string picknoo)
        {
            try
            {
                var deletePickup = await _db.pum_pickuprequest.FirstOrDefaultAsync(p => p.pickupno == picknoo);
                if (deletePickup == null)
                {
                    return "not found";
                }

                _db.pum_pickuprequest.Remove(deletePickup);
                await _db.SaveChangesAsync();

                return "Delete Success";
            }
            catch (DbUpdateException dbEx)
            {
                return $"Database error: {dbEx.Message}";
            }
            catch (Exception ex)
            {
                return $"An unexpected error occurred: {ex.Message}";
            }
        }

        public async Task<Branch> FindBranchName(string branchNamee)
        {
            var data = await _db.mdt_branch.FirstOrDefaultAsync(p => p.branchname == branchNamee);

            return data;
            
        }

        public async Task<Account> FindAccountName(string acctNooo)
        {
            var data = await _db.mdt_account.FirstOrDefaultAsync(p => p.acctno == acctNooo);

            return data;

        }
        public async Task<Courier> FindCourierName(string courierCode)
        {
            var data = await _db.mdt_courier.FirstOrDefaultAsync(p => p.couriercode == courierCode);

            return data;

        }

        #endregion

        #region "Control Status Pickup"
        #endregion

        #region "Monitoring Pickup"
        #endregion
    }
}
