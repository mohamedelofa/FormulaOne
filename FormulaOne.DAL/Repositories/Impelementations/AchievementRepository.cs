using FormulaOne.DAL.Data;
using FormulaOne.DAL.Models;
using FormulaOne.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DAL.Repositories.Impelementations
{
    public class AchievementRepository : GenericRepository<Achievement>,IAchievementRepository
    {
        public AchievementRepository(AppDbContext context , ILogger logger) : base(context , logger) { }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            try
            {
                return await _db.Where(a => a.Status == 1).OrderByDescending(a => a.CreatedDate).AsNoTracking().FirstOrDefaultAsync(a => a.DriverId == driverId);
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "{@repository} GetDriverAchievementsAsync Function Error", typeof(AchievementRepository));
                throw;
            }
        }


        public override async Task<IEnumerable<Achievement>> GetAllAsync()
        {
            try
            {
                return await _db.Where(d => d.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(d => d.CreatedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} GetAll Function Error", typeof(AchievementRepository));
                throw;
            }
        }

        public async override Task<Achievement?> GetByIdAsync(Guid id, bool tracked = false)
        {
            try
            {
                if (tracked)
                    return await base.GetByIdAsync(id);
                return await _db.AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} GetById Function Error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task AddAsync(Achievement entity)
        {
            try
            {
                await base.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} Add Function Error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task DeleteAsync(Achievement entity)
        {
            try
            {
                entity.Status = 0;
                entity.UpdatedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} Delete Function Error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task UpdateAsync(Achievement entity)
        {
            try
            {
               await base.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} Update Function Error", typeof(AchievementRepository));
                throw;
            }
        }
    }
}
