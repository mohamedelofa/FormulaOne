using FormulaOne.BAL.DTOS.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Commands.DriverCommands
{
    public class UpdateDriverCommand : IRequest<bool>
    {
        public UpdateDriverDto DriverDto { get; }
        public UpdateDriverCommand(UpdateDriverDto driverDto)
        {
            DriverDto = driverDto;
        }
    }
}
