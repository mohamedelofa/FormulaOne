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
    internal class DeleteAchievementCommandHandler(IAchievementService achievementService) : IRequestHandler<DeleteAchievementCommand, bool>
    {
        private readonly IAchievementService _achievementService = achievementService;
        public async Task<bool> Handle(DeleteAchievementCommand request, CancellationToken cancellationToken)
        {
            return await _achievementService.DleteAsync(request.AchievementId);
        }
    }
}
