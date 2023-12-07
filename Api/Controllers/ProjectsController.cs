
using Application.Commands.ProjectCommands.CreateProject;
using Application.Commands.ProjectCommands.DeleteProject;
using Application.Commands.ProjectCommands.UpdateProject;
using Application.Queries.ProjectQueries.GetProjectDetails;
using Application.Queries.ProjectQueries.GetProjectList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]

    public partial class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        public async Task<ActionResult<List<GetProjectListDto>>> GetAllProjects()
        {
            var projects = await _mediator.Send(new GetProjectListQuery());
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] CreateProjectCommand project)
        {
            await _mediator.Send(project);
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var command = new DeleteProjectCommand() { ProjectId = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("GetProjectById/{id}")]
        public async Task<ActionResult<GetProjectDetailsDto>> GetProjecById(int id)
        {
            var Tasks = await _mediator.Send(new GetProjectDetailsQuery { Id = id });
            return Ok(Tasks);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateProject([FromBody] UpdateProjectCommand project)
        {

            await _mediator.Send(project);
            return Ok();

        }
    }
}
