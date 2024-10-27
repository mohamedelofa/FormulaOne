using FormulaOne.BAL.DTOS.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Commands.DriverCommands
{
    public class CreateDriverCommand : IRequest<bool>
    {
        public CreateDriverDto Driver { get; }
        public CreateDriverCommand(CreateDriverDto driver)
        {
            Driver = driver;
        }
    }
}
