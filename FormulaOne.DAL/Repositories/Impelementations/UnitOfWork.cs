using FormulaOne.DAL.Data;
using FormulaOne.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DAL.Repositories.Impelementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IDriverRepository DriverRepository { get; }
        public IAchievementRepository AchievementRepository { get; }
        public UnitOfWork(AppDbContext context , ILogger<UnitOfWork> logger)
        {
            _context = context;
            DriverRepository = new DriverRepository(_context, logger);
            AchievementRepository = new AchievementRepository(_context, logger);
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
