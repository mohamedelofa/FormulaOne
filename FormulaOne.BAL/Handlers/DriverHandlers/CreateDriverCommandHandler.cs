using FormulaOne.BAL.Commands.DriverCommands;
using FormulaOne.BAL.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Handlers.DriverHandlers
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, bool>
    {
        private readonly IDriverService _driverService;
        public CreateDriverCommandHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task<bool> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            return await _driverService.AddAsync(request.Driver);
        }
    }
}
