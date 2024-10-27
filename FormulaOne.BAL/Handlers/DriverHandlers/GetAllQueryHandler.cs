using FormulaOne.BAL.DTOS.Responses;
using FormulaOne.BAL.Queries.DriverQueries;
using FormulaOne.BAL.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Handlers.DriverHandlers
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<DriverResponseDto>>
    {
        private IDriverService _driverService;
        public GetAllQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task<IEnumerable<DriverResponseDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _driverService.GetAllAsync();
        }
    }
}
