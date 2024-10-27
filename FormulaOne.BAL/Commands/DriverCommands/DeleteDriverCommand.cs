using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Commands.DriverCommands
{
    public class DeleteDriverCommand : IRequest<bool>
    {
        public Guid DriverId { get; }
        public DeleteDriverCommand(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}
