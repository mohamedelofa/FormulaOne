using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DAL.Models
{
    public class Achievement : BaseEntity
    {
        public int RaceWins { get; set; }
        public int PolePosition { get; set; }
        public int FastestLap { get; set; }
        public int WorldChampionsChip { get; set; }
        public Guid DriverId { get; set; }
        public Driver? Driver { get; set; }
    }
}
