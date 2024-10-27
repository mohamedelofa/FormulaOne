using AutoMapper;
using FormulaOne.BAL.DTOS.Requests;
using FormulaOne.BAL.DTOS.Responses;
using FormulaOne.BAL.Services.Interfaces;
using FormulaOne.DAL.Models;
using FormulaOne.DAL.Repositories.Impelementations;
using FormulaOne.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Services.Implementation
{
    public class AchievementService : IAchievementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AchievementService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(CreateDriverAchievementDto entity)
        {
            if (entity is null) return false;
            if (await _unitOfWork.DriverRepository.GetByIdAsync(entity.DriverId) is null) return false;
            var model = _mapper.Map<Achievement>(entity);
            await _unitOfWork.AchievementRepository.AddAsync(model);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DleteAsync(Guid id)
        {
            var achievement = await _unitOfWork.AchievementRepository.GetByIdAsync(id , true);
            if (achievement is null) return false;
            if(achievement.Status == 0) return false;
            await _unitOfWork.AchievementRepository.DeleteAsync(achievement);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<DriverAchievementResponseDto>> GetAllAsync()
        {
            var achievements = await _unitOfWork.AchievementRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DriverAchievementResponseDto>>(achievements);
        }

        public async Task<DriverAchievementResponseDto?> GetByIdAsync(Guid id)
        {
            var achievement = await _unitOfWork.AchievementRepository.GetByIdAsync(id);
            if (achievement is null || achievement.Status == 0 ) return null;
            return _mapper.Map<DriverAchievementResponseDto>(achievement);
        }

        public async Task<bool> UpdateAsync(UpdateDriverAchievementDto entity)
        {
            var achievement = await _unitOfWork.AchievementRepository.GetByIdAsync(entity.AchievementId);
            if (achievement is null || achievement.Status == 0) return false;
            if (await _unitOfWork.DriverRepository.GetByIdAsync(entity.DriverId) is null) return false;
            var createdate = achievement.CreatedDate;
            achievement = _mapper.Map<Achievement>(entity);
            achievement.CreatedDate = createdate;
            await _unitOfWork.AchievementRepository.UpdateAsync(achievement);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<DriverAchievementResponseDto?> GetDriverAchievementAsync(Guid driverId)
        {
            var driver = await _unitOfWork.DriverRepository.GetByIdAsync(driverId);
            if (driver is null || driver.Status == 0) return null;
            var result = await _unitOfWork.AchievementRepository.GetDriverAchievementAsync(driverId);
            if (result is null) return null;
            return _mapper.Map<DriverAchievementResponseDto>(result);
        }
    }
}
