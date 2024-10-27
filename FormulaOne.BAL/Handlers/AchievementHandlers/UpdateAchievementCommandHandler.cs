using FormulaOne.BAL.Commands.AchievementCommands;
using FormulaOne.BAL.Services.Implementation;
using FormulaOne.BAL.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Handlers.AchievementHandlers
{
    internal class UpdateAchievementCommandHandler(IAchievementService achievementService) : IRequestHandler<UpdateAchievementCommand, bool>
    {
        private readonly IAchievementService _achievementService = achievementService;
        public async Task<bool> Handle(UpdateAchievementCommand request, CancellationToken cancellationToken)
        {
            return await _achievementService.UpdateAsync(request.AchievementDto);
        }
    }
}
