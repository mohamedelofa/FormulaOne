using FormulaOne.BAL.Commands.AchievementCommands;
using FormulaOne.BAL.DTOS.Requests;
using FormulaOne.BAL.Queries.AchievementQueries;
using FormulaOne.BAL.Services.Implementation;
using FormulaOne.BAL.Services.Interfaces;
using FormulaOne.DAL.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AchievementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("D/{driverId:Guid}")]
        public async Task<IActionResult> GetDriverAchievement(Guid driverId)
        {
            var query = new GetDriverAchievementQuery(driverId);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var query = new GetByIdQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDriverAchievementDto model)
        {
            if (model is null) return BadRequest();
            var command = new CreateAchievementCommand(model);
            bool result = await _mediator.Send(command);
            return result ? Created() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateDriverAchievementDto model)
        {
            if (model is null) return BadRequest();
            var command = new UpdateAchievementCommand(model);
            bool result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var command = new DeleteAchievementCommand(id);
            bool result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}
