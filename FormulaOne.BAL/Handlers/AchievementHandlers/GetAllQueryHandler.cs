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
    internal class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<DriverAchievementResponseDto>>
    {
        private readonly IAchievementService _achievementService;
        public GetAllQueryHandler(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }
        public async Task<IEnumerable<DriverAchievementResponseDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _achievementService.GetAllAsync();
        }
    }
}
