using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDriverRepository DriverRepository { get; }
        IAchievementRepository AchievementRepository { get; }

        Task<bool> CompleteAsync();
    }
}
