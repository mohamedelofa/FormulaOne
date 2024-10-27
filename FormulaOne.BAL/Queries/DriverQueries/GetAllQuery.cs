using FormulaOne.BAL.DTOS.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Queries.DriverQueries
{
    public class GetAllQuery : IRequest<IEnumerable<DriverResponseDto>>
    {

    }
}
