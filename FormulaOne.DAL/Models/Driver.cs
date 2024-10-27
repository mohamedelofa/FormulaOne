using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DAL.Models
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int DriverNumber { get; set; }
        public ICollection<Achievement> Achievements { get; set; } = new HashSet<Achievement>();
    }
}
