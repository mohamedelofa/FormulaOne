using FormulaOne.BAL.DTOS.Requests;
using FormulaOne.BAL.DTOS.Responses;
using FormulaOne.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Services.Interfaces
{
    public interface IAchievementService
    {
        Task<IEnumerable<DriverAchievementResponseDto>> GetAllAsync();
        Task<DriverAchievementResponseDto?> GetByIdAsync(Guid id);
        Task<bool> AddAsync(CreateDriverAchievementDto entity);
        Task<bool> UpdateAsync(UpdateDriverAchievementDto entity);
        Task<bool> DleteAsync(Guid id);
        Task<DriverAchievementResponseDto?> GetDriverAchievementAsync(Guid driverId);
    }
}
