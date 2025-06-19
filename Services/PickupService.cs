
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace iDss.X.Services
{
    public class PickupService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public PickupService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        #region "Entry Data Pickup"
        public async Task<List<PickupRequest>> GetPickupRequestAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.pum_pickuprequest
                .Include(c => c.Branch)
                .Include(c => c.District)
                .AsNoTracking()
                .OrderByDescending(c => c.createddate)
                .ToListAsync();
            return await result;
        }

        public async Task<List<PickupStatusPool>> GetPickupStatusPoolAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.pum_pickupstatuspool
                .AsNoTracking()
                .OrderByDescending(c => c.createddate)
                .ToListAsync();
            return await result;
        }

        public async Task<List<PickupRegular>> GetPickupRegularAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.pum_pickupregular
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

        public async Task<QueryData<PickupRequest>> OnQueryDispatchCourierAsync(QueryPageOptions options)
        {
            // Ambil semua pickup request
            var items = await GetPickupRequestAsync();

            // Ambil status pool
            var statusPool = await GetPickupStatusPoolAsync();

            // Buat dictionary pickupno => status (flag = 1)
            var statuses = statusPool
                .Where(x => x.flag == 1)
                .GroupBy(x => x.pickupno)
                .ToDictionary(
                    g => g.Key,
                    g => g.FirstOrDefault()?.pickupstatus?.Trim().ToLowerInvariant() ?? "unknown"
                );

            // Daftar status yang diperbolehkan
            var allowedStatuses = new[] { "assign", "dispatched" };

            // Filter hanya pickup dengan status sesuai allowedStatuses
            items = items
                .Where(x => statuses.TryGetValue(x.pickupno, out var status) && allowedStatuses.Contains(status))
                .ToList();

            var isSearched = false;

            // Pencarian manual (by model)
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

                isSearched = !string.IsNullOrEmpty(model.pickupno) || !string.IsNullOrEmpty(model.pickuptype);
            }

            // Pencarian umum (fuzzy search)
            if (options.Searches.Any())
            {
                items = items.Where(options.Searches.GetFilterFunc<PickupRequest>(FilterLogic.Or)).ToList();
            }

            // Filtering by column
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<PickupRequest>()).ToList();
                isFiltered = true;
            }

            // Pagination
            var total = items.Count();
            var pagedItems = items
                .Skip((options.PageIndex - 1) * options.PageItems)
                .Take(options.PageItems)
                .ToList();

            return await Task.FromResult(new QueryData<PickupRequest>()
            {
                Items = pagedItems,
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSearch = isSearched
            });
        }

        public async Task<QueryData<PickupRequest>> OnQueryAssignAsync(QueryPageOptions options)
        {
            // Ambil semua pickup request
            var items = await GetPickupRequestAsync();

            // Ambil status pool
            var statusPool = await GetPickupStatusPoolAsync();

            // Buat dictionary pickupno => status (flag = 1)
            var statuses = statusPool
                .Where(x => x.flag == 1)
                .GroupBy(x => x.pickupno)
                .ToDictionary(
                    g => g.Key,
                    g => g.FirstOrDefault()?.pickupstatus?.Trim().ToLowerInvariant() ?? "unknown"
                );

            // Daftar status yang diperbolehkan
            var allowedStatuses = new[] { "assign", "open", "reassign" };

            // Filter hanya pickup dengan status sesuai allowedStatuses
            items = items
                .Where(x => statuses.TryGetValue(x.pickupno, out var status) && allowedStatuses.Contains(status))
                .ToList();

            var isSearched = false;

            // Pencarian manual (by model)
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

                isSearched = !string.IsNullOrEmpty(model.pickupno) || !string.IsNullOrEmpty(model.pickuptype);
            }

            // Pencarian umum (fuzzy search)
            if (options.Searches.Any())
            {
                items = items.Where(options.Searches.GetFilterFunc<PickupRequest>(FilterLogic.Or)).ToList();
            }

            // Filtering by column
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<PickupRequest>()).ToList();
                isFiltered = true;
            }

            // Pagination
            var total = items.Count();
            var pagedItems = items
                .Skip((options.PageIndex - 1) * options.PageItems)
                .Take(options.PageItems)
                .ToList();

            return await Task.FromResult(new QueryData<PickupRequest>()
            {
                Items = pagedItems,
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSearch = isSearched
            });
        }



        public async Task<QueryData<PickupRegular>> OnQueryPickupRegularAsync(QueryPageOptions options)
        {
            var items = await GetPickupRegularAsync();

            var isSearched = false;

            if (options.SearchModel is PickupRegular model)
            {
                if (model.id != 0)
                {
                    items = items.Where(item => item.id == model.id).ToList();
                }

                if (!string.IsNullOrEmpty(model.pickuptype))
                {
                    items = items.Where(item => item.pickuptype?.Contains(model.pickuptype, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = model.id != 0 || !string.IsNullOrEmpty(model.pickuptype);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<PickupRegular>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<PickupRegular>()).ToList();
                isFiltered = true;
            }

            var total = items.Count();

            return await Task.FromResult(new QueryData<PickupRegular>()
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
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.pum_pickuprequest
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
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.pum_pickuprequest.FindAsync(id);
            return await result;
        }

        public async Task<PickupRegular> GetPickupRegularByIDAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var result = _context.pum_pickupregular.FindAsync(id);
            return await result;
        }

        public async Task<string?> GeneratePickupNoAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            var today = DateTime.UtcNow.Date;
            int countToday = await _context.pum_pickuprequest
                .CountAsync(p => p.createddate >= today && p.createddate < today.AddDays(1));

            if (countToday >= 9999)
                return null; // Melebihi batas per hari

            string datePart = DateTime.UtcNow.ToString("yyMMdd");
            string serialPart = (countToday + 1).ToString("D4");

            return datePart + serialPart;
        }

        public async Task<PickupRequest> GetPickupRequestByPickno(string pickno)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.pum_pickuprequest.FirstOrDefaultAsync(p => p.pickupno == pickno);
        }

        public async Task<bool> SavePickupRequestAsync(PickupRequest data, ItemChangedType changedType)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                if (changedType == ItemChangedType.Add)
                {
                    data.createdby = "user.login"; //ganti dengan username by session login
                    data.createddate = DateTime.Now.ToUniversalTime();
                    _context.pum_pickuprequest.Add(data);
                }
                else
                {
                    var existingEntity = await _context.pum_pickuprequest.FindAsync(data.id);

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

                var status = new PickupStatusPool
                {
                    pickupno = data.pickupno,
                    pickupstatus = "open"
                };
                _context.pum_pickupstatuspool.Add(status);
                await _context.SaveChangesAsync();

                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> AssignCourierAsync(PickupRequest data, ItemChangedType changedType)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                if (changedType == ItemChangedType.Add)
                {
                    var status = new PickupStatusPool
                    {
                        pickupno = data.pickupno,
                        pickupstatus = "assign"
                    };
                    status.createdby = "user.login"; //ganti dengan username by session login
                    status.createddate = DateTime.Now.ToUniversalTime();
                    _context.pum_pickupstatuspool.Add(status);
                }
                else
                {
                    var existingEntity = await _context.pum_pickupstatuspool.FindAsync(data.id);

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

        public async Task<bool> ReassignPickupStatusAsync(PickupRequest data,string pickupNoo, ItemChangedType changedType)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                if (changedType == ItemChangedType.Update)
                {
                    var status = await _context.pum_pickupstatuspool
                        .Where(x => x.pickupno == pickupNoo)
                        .OrderByDescending(x => x.createddate)
                        .FirstOrDefaultAsync();
                    if (status != null)
                    {
                        status.flag = 0;
                        _context.pum_pickupstatuspool.Update(status);

                        var newStatus = new PickupStatusPool
                        {
                            pickupno = status.pickupno,
                            pickupstatus = "reassign",
                            createdby = "user.login",
                            createddate = DateTime.UtcNow,
                        };
                        _context.pum_pickupstatuspool.Add(newStatus);
                    }
                }
                else
                {
                    var existingEntity = await _context.pum_pickupstatuspool.FindAsync(data.id);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }

                var dataCourier = await _context.pum_pickuprequest
                        .FirstOrDefaultAsync(x => x.pickupno == pickupNoo);
                if (dataCourier != null)
                {
                    dataCourier.couriercode = null;
                    dataCourier.couriername = null;
                    dataCourier.modifier = "user.login";
                    dataCourier.modifieddate = DateTime.UtcNow;

                    _context.pum_pickuprequest.Update(dataCourier);
                    await _context.SaveChangesAsync();
                }

                return true; // Jika berhasil
            }
            catch (Exception)
            {
                return false; // Jika gagal
            }
        }

        public async Task<bool> UpdatePickupStatusAsync(PickupRequest data, ItemChangedType changedType)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                if (changedType == ItemChangedType.Update)
                {
                    var status = await _context.pum_pickupstatuspool
                        .Where(x => x.pickupno == data.pickupno)
                        .OrderByDescending(x => x.createddate)
                        .FirstOrDefaultAsync();
                    if (status != null)
                    {
                        status.flag = 0;
                        _context.pum_pickupstatuspool.Update(status);
                    }
                }
                else
                {
                    var existingEntity = await _context.pum_pickupstatuspool.FindAsync(data.pickupno);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }
                    // Attach ulang data yang baru dan update
                    _context.Attach(data);
                    _context.Entry(data).State = EntityState.Modified;
                }
             

                var dataCourier = await _context.pum_pickuprequest
                        .FirstOrDefaultAsync(x => x.pickupno == data.pickupno);
                if (dataCourier != null)
                {
                    dataCourier.couriercode = data.couriercode;
                    dataCourier.couriername = data.couriername;
                    dataCourier.modifier = "user.login"; //ganti dengan username by session login
                    dataCourier.modifieddate = DateTime.Now.ToUniversalTime();
                    _context.pum_pickuprequest.Update(dataCourier);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DispatchAsync(PickupRequest data,string pickupNoo , ItemChangedType changedType)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                if (changedType == ItemChangedType.Update)
                {
                    var status = await _context.pum_pickupstatuspool
                        .Where(x => x.pickupno == pickupNoo)
                        .OrderByDescending(x => x.createddate)
                        .FirstOrDefaultAsync();
                    if (status != null)
                    {
                        status.flag = 0;
                        _context.pum_pickupstatuspool.Update(status);

                        var newStatus = new PickupStatusPool
                        {
                            pickupno = status.pickupno,
                            pickupstatus = "dispatched",
                            createdby = "user.login",
                            createddate = DateTime.UtcNow,
                        };
                        _context.pum_pickupstatuspool.Add(newStatus);
                    }
                }
                else
                {
                    var existingEntity = await _context.pum_pickupstatuspool.FindAsync(data.pickupno);

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
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePickupRequestAsync(PickupRequest data, ItemChangedType changedType)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                if (changedType == ItemChangedType.Update)
                {
                    data.modifier = "user.login"; //ganti dengan username by session login
                    data.modifieddate = DateTime.Now.ToUniversalTime();
                    _context.pum_pickuprequest.Update(data);
                }
                else
                {
                    var existingEntity = await _context.pum_pickuprequest.FindAsync(data.pickupno);

                    if (existingEntity != null )
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }
                    // Attach ulang data yang baru dan update
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

        public async Task<bool> DeletePickupRequestByIDAsync(IEnumerable<PickupRequest> pickupRequests)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                foreach (var pickupRequest in pickupRequests)
                {
                    var existing = await _context.pum_pickuprequest.FindAsync(pickupRequest.pickupno);
                    if (existing != null)
                    {
                        _context.pum_pickuprequest.Remove(existing);
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
        public async Task<bool> DeletePickupRegularByIDAsync(IEnumerable<PickupRegular> pickupRegulars)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                foreach (var item in pickupRegulars)
                {
                    var existingSchedulers = await _context.pum_pickupschedule.Where(p => p.puregid == item.id).ToListAsync();
                    if (existingSchedulers.Any())
                    {
                        _context.pum_pickupschedule.RemoveRange(existingSchedulers);
                    }
                }

                foreach (var pickupRegular in pickupRegulars)
                {
                    var existingRegular = await _context.pum_pickupregular.FindAsync(pickupRegular.id);
                    if (existingRegular != null)
                    {
                        _context.pum_pickupregular.Remove(existingRegular);
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


        public async Task<string> DeletePickupByPickno(string picknoo)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                var deletePickup = await _context.pum_pickuprequest.FirstOrDefaultAsync(p => p.pickupno == picknoo);
                if (deletePickup == null)
                {
                    return "not found";
                }

                _context.pum_pickuprequest.Remove(deletePickup);
                await _context.SaveChangesAsync();

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

        #endregion

        #region "Control Status Pickup"

        public async Task<string> SavePickupRegularAsync(PickupRegular dataRegular, List<PickupSchedule> dataSchedules, ItemChangedType changedType)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                if (changedType == ItemChangedType.Add)
                {
                    dataRegular.createdby = "user.login"; //ganti dengan username by session login
                    dataRegular.createddate = DateTime.Now.ToUniversalTime();
                    _context.pum_pickupregular.Add(dataRegular);
                }
                else
                {
                    var existingEntity = await _context.pum_pickupregular.FindAsync(dataRegular.id);

                    if (existingEntity != null)
                    {
                        // Pastikan instance lama tidak menyebabkan error
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Attach ulang data yang baru dan update
                    _context.Attach(dataRegular);
                    _context.Entry(dataRegular).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();

                int regularId = dataRegular.id;

                var newSchedules = dataSchedules.Select(d => new PickupSchedule
                {
                    puregid = dataRegular.id,
                    pickupday = d.pickupday,
                    shift = d.shift,
                    timefrom = d.timefrom,
                    timeto = d.timeto
                }).ToList();
                _context.pum_pickupschedule.AddRange(newSchedules);
                await _context.SaveChangesAsync();
                return "success"; // Jika berhasil
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

        public async Task<string> DeleteRegularAsync(int id)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                var deletePickupScheduler = await _context.pum_pickupschedule.FirstOrDefaultAsync(p => p.id == id);
                if (deletePickupScheduler == null)
                {
                    return "not found";
                }

                _context.pum_pickupschedule.Remove(deletePickupScheduler);
                await _context.SaveChangesAsync();

                var deletePickupRegular = await _context.pum_pickupregular.FirstOrDefaultAsync(p => p.id == id);
                if (deletePickupRegular == null)
                {
                    return "not found";
                }

                _context.pum_pickupregular.Remove(deletePickupRegular);
                await _context.SaveChangesAsync();

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

        public async Task<List<PickupSchedule>> GetPickupSchedulesByiD(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.pum_pickupschedule.Where(p => p.puregid == id).ToListAsync();
        }

        public async Task CreateScheduleAsync(PickupSchedule schedule)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.pum_pickupschedule.Add(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateScheduleAsync(PickupSchedule schedule)
        {
            using var _context = _contextFactory.CreateDbContext();
            var existing = await _context.pum_pickupschedule.FindAsync(schedule.id);
            if (existing != null)
            {
                existing.timefrom = schedule.timefrom;
                existing.timeto = schedule.timeto;
                existing.pickupday = schedule.pickupday;
                existing.shift = schedule.shift;

                _context.pum_pickupschedule.Update(existing);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> DeleteScheduleAsync(int id)
        {
            try
            {
                using var _context = _contextFactory.CreateDbContext();
                var deletePickup = await _context.pum_pickupschedule.FirstOrDefaultAsync(p => p.id == id);
                if (deletePickup == null)
                {
                    return "not found";
                }

                _context.pum_pickupschedule.Remove(deletePickup);
                await _context.SaveChangesAsync();

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
        #endregion

        #region "Monitoring Pickup"
        #endregion
    }
}
