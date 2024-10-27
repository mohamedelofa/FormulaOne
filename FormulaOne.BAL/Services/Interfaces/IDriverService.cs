using FormulaOne.BAL.DTOS.Requests;
using FormulaOne.BAL.DTOS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Services.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverResponseDto>> GetAllAsync();
        Task<DriverResponseDto?> GetByIdAsync(Guid id);
        Task<bool> AddAsync(CreateDriverDto entity);
        Task<bool> UpdateAsync(UpdateDriverDto entity);
        Task<bool> DleteAsync(Guid id);
    }
}
