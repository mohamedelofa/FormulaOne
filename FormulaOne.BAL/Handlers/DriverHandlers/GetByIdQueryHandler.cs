using FormulaOne.BAL.DTOS.Responses;
using FormulaOne.BAL.Queries.DriverQueries;
using FormulaOne.BAL.Services.Implementation;
using FormulaOne.BAL.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Handlers.DriverHandlers
{
    internal class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, DriverResponseDto?>
    {
        private readonly IDriverService _driverService;
        public GetByIdQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task<DriverResponseDto?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _driverService.GetByIdAsync(request.DriverId);
            return result is not null ? result : null;
        }
    }
}
