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
    internal class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly IDriverService _driverService;
        public DeleteDriverCommandHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            return await _driverService.DleteAsync(request.DriverId);
        }
    }
}
