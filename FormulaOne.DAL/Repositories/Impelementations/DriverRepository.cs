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
    public class DriverRepository : GenericRepository<Driver> , IDriverRepository
    {
        public DriverRepository(AppDbContext context,ILogger logger):base(context , logger) { }

        public override async Task<IEnumerable<Driver>> GetAllAsync()
        {
            try
            {
                return await _db.Where(d => d.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(d => d.CreatedDate)
                    .ToListAsync();
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex,"{@repository} GetAll Function Error",typeof(DriverRepository));
                throw;
            }
        }

        public async override Task<Driver?> GetByIdAsync(Guid id , bool tracked = false)
        {
            try
            {
                if(tracked)
                    return await base.GetByIdAsync(id);
                return await _db.AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} GetById Function Error", typeof(DriverRepository));
                throw;
            }
        }

        public async override Task AddAsync(Driver entity)
        {
            try
            {
                await base.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} Add Function Error", typeof(DriverRepository));
                throw;
            }
        }

        public override async Task DeleteAsync(Driver entity)
        {
            try
            {
                entity.Status = 0;
                entity.UpdatedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} Delete Function Error", typeof(DriverRepository));
                throw;
            }
        }

        public override async Task UpdateAsync(Driver entity)
        {
            try
            {
                await base.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@repository} Update Function Error", typeof(DriverRepository));
                throw;
            }
        }
    }
}
