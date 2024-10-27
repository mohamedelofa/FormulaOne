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
    internal class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, bool>
    {
        private readonly IDriverService _driverService;
        public UpdateDriverCommandHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task<bool> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            return await _driverService.UpdateAsync(request.DriverDto);
        }
    }
}
