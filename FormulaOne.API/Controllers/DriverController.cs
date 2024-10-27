using FormulaOne.BAL.Commands.DriverCommands;
using FormulaOne.BAL.DTOS.Requests;
using FormulaOne.BAL.Queries.DriverQueries;
using FormulaOne.BAL.Services.Interfaces;
using FormulaOne.DAL.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            GetAllQuery query = new();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:GUid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            GetByIdQuery query = new(id);
            var result = await _mediator.Send(query);
            return result is not  null ? Ok(result) : NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDriverDto model)
        {
            if (model is null) return BadRequest();
            var command = new CreateDriverCommand(model);
            bool result = await _mediator.Send(command);
            return result ? Created() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateDriverDto model)
        {
            if(model is null) return BadRequest();
            var command = new UpdateDriverCommand(model);
            bool result = await _mediator.Send(command);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var command = new DeleteDriverCommand(id);
            bool result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}
