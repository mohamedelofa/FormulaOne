using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.DTOS.Responses
{
    public class DriverAchievementResponseDto
    {
        public Guid AchievementId { get; set; }
        public Guid DriverId { get; set; }
        public int RaceWins { get; set; }
        public int PolePosition { get; set; }
        public int FastestLap { get; set; }
        public int WorldChampionsChip { get; set; }
    }
}
