using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Commands.AchievementCommands
{
    public class DeleteAchievementCommand(Guid achievementId) : IRequest<bool>
    {
        public Guid AchievementId { get; } = achievementId;
    }
}
