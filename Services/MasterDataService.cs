
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;

namespace iDss.X.Services
{
    public class MasterDataServices
    {
        private readonly AppDbContext _context;
        public MasterDataServices(AppDbContext context)
        {
            _context = context;
        }

        #region "Incident Category"
        public async Task<List<Checkpoint>> GetCheckpointAsync()
        {
            var result = _context.mdt_checkpoint
                .OrderByDescending(c => c.createddate)
                .ToListAsync();
            return await result;
        }

        public async Task<List<Checkpoint>> GetCheckpointComboAsync()
        {
            var result = _context.mdt_checkpoint
                                .Select(p => new Checkpoint()
                                {
                                    cpcode = p.cpcode,
                                    cpname = p.cpname,
                                })
                .ToListAsync();
            return await result;
        }
        public async Task<Checkpoint> GetCheckpointByIDAsync(Guid id)
        {
            var result = _context.mdt_checkpoint.FindAsync(id);
            return await result;
        }
        public async Task<string> CreateCheckpointAsync(Checkpoint data)
        {
            string result;
            try
            {
                data.createddate = DateTime.Now.ToUniversalTime();
                _context.mdt_checkpoint.Add(data);
                await _context.SaveChangesAsync();
                result = "ok";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public async Task<string> UpdateCheckpointAsync(Checkpoint data)
        {
            string result;
            try
            {
                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                result = "ok";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public async Task<string> DeleteCheckpointByIDAsync(String code)
        {
            string result;
            try
            {
                var data = await _context.mdt_checkpoint.FindAsync(code);

                if (data != null)
                {
                    _context.mdt_checkpoint.Remove(data);
                    await _context.SaveChangesAsync();
                }

                result = "ok";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        #endregion
    }
}
