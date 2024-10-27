using FormulaOne.DAL.Data;
using FormulaOne.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DAL.Repositories.Impelementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected ILogger _logger;
        protected readonly DbSet<T> _db;
        public GenericRepository(AppDbContext context , ILogger logger)
        {
            _context = context;
            _logger = logger;
            _db = _context.Set<T>();
        }
        public virtual async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id , bool tracked = false)
        {
            return await _db.FindAsync(id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
           _db.Update(entity);
        }

    }
}
