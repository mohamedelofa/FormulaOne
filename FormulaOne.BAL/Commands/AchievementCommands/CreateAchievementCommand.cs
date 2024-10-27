using FormulaOne.BAL.DTOS.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Commands.AchievementCommands
{
    public class CreateAchievementCommand(CreateDriverAchievementDto achievementDto) : IRequest<bool>
    {
        public CreateDriverAchievementDto AchievementDto { get; } = achievementDto;
    }
}
