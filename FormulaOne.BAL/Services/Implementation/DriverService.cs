using AutoMapper;
using FormulaOne.BAL.DTOS.Requests;
using FormulaOne.BAL.DTOS.Responses;
using FormulaOne.BAL.Services.Interfaces;
using FormulaOne.DAL.Models;
using FormulaOne.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Services.Implementation
{
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DriverService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(CreateDriverDto entity)
        {
            if (entity is null) return false;
            var model = _mapper.Map<Driver>(entity);
            await _unitOfWork.DriverRepository.AddAsync(model);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DleteAsync(Guid id)
        {
            Driver? driver = await _unitOfWork.DriverRepository.GetByIdAsync(id , true);
            if (driver is null) return false;
            if (driver.Status == 0) return false;
            await _unitOfWork.DriverRepository.DeleteAsync(driver);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<DriverResponseDto>> GetAllAsync()
        {
            var drivers = await _unitOfWork.DriverRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DriverResponseDto>>(drivers);
        }

        public async Task<DriverResponseDto?> GetByIdAsync(Guid id)
        {
            Driver? driver = await _unitOfWork.DriverRepository.GetByIdAsync(id);
            if(driver is null) return null;
            if (driver.Status == 0) return null;
            return _mapper.Map<DriverResponseDto>(driver);
        }

        public async Task<bool> UpdateAsync(UpdateDriverDto entity)
        {
            Driver? driver = await _unitOfWork.DriverRepository.GetByIdAsync(entity.DriverId);
            if (driver is null) return false;
            if (driver.Status == 0) return false;
            var creatdate = driver.CreatedDate;
            driver = _mapper.Map<Driver>(entity);
            driver.CreatedDate = creatdate;
            await _unitOfWork.DriverRepository.UpdateAsync(driver);
            return await _unitOfWork.CompleteAsync();
        }
    }
}
