using FormulaOne.BAL.DTOS.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Commands.AchievementCommands
{
    public class UpdateAchievementCommand(UpdateDriverAchievementDto achievementDto) : IRequest<bool>
    {
        public UpdateDriverAchievementDto AchievementDto { get; } = achievementDto;
    }
}
