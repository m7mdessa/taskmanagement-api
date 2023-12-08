using Application.Commands.DeveloperCommands.CreateDeveloper;
using Application.Commands.DeveloperCommands.DeleteDeveloper;
using Application.Commands.DeveloperCommands.UpdateDeveloper;
using Application.Queries.DeveloperQueries.GetDeveloperDetails;
using Application.Queries.DeveloperQueries.GetDeveloperList;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public DevelopersController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<ActionResult<List<GetDeveloperListDto>>> GetAllDevelopers()
        {
            var developers = await _mediator.Send(new GetDeveloperListQuery());
            return Ok(developers);
        }



        [HttpPost]
        public async Task<ActionResult> CreateDeveloper([FromBody] CreateDeveloperCommand developer)
        {
            await _mediator.Send(developer);
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteDeveloper(int id)
        {
            var command = new DeleteDeveloperCommand() { RoleId = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("GetDeveloperById/{id}")]
        public async Task<ActionResult<GetDeveloperDetailsDto>> GetDeveloperById(int id)
        {
            var developer = await _mediator.Send(new GetDeveloperDetailsQuery { Id = id });
            return Ok(developer);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateDeveloper([FromBody] UpdateDeveloperCommand developer)
        {

            await _mediator.Send(developer);
            return Ok();

        }


    }
}
