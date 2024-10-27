using FormulaOne.BAL.DTOS.Responses;
using FormulaOne.BAL.Queries.AchievementQueries;
using FormulaOne.BAL.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Handlers.AchievementHandlers
{
    internal class GetByIdQueryHandler(IAchievementService achievementService) : IRequestHandler<GetByIdQuery, DriverAchievementResponseDto?>
    {
        private readonly IAchievementService _achievementService = achievementService;
        public async Task<DriverAchievementResponseDto?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _achievementService.GetByIdAsync(request.DriverId);
            return result is not null ? result : null;
        }
    }
}
