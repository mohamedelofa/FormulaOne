using FormulaOne.BAL.DTOS.Responses;
using FormulaOne.BAL.Queries.AchievementQueries;
using FormulaOne.BAL.Services.Interfaces;
using FormulaOne.DAL.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Handlers.AchievementHandlers
{
    internal class GetDriverAchievementQueryHandler(IAchievementService achievementService) : IRequestHandler<GetDriverAchievementQuery, DriverAchievementResponseDto?>
    {
        private readonly IAchievementService _achievementService = achievementService;
        public async Task<DriverAchievementResponseDto?> Handle(GetDriverAchievementQuery request, CancellationToken cancellationToken)
        {
            var achievement = await _achievementService.GetDriverAchievementAsync(request.DriverId);
            return achievement is not null ? achievement : null; 
        }
    }
}
