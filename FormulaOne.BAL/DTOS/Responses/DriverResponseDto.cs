using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.DTOS.Responses
{
    public class DriverResponseDto
    {
        public Guid DriverId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int DriverNumber { get; set; }
    }
}
