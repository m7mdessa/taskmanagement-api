using Application.Commands.ProjectCommands.CreateProject;
using Application.Commands.ProjectCommands.DeleteProject;
using Application.Commands.ProjectCommands.UpdateProject;
using Application.Queries.ProjectQueries.GetProjectDetails;
using Application.Queries.ProjectQueries.GetProjectList;
using Domain.Aggregates.ProjectAggregate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public partial class ProjectsController : ControllerBase
    {
        #region Projects

        private readonly IMediator _mediator;
        private readonly IProjectRepository _projectRepository;

      
        public ProjectsController(IMediator mediator, IProjectRepository projectRepository)
        {
            _mediator = mediator;
            _projectRepository = projectRepository;

        }


        [HttpGet]
        public async Task<ActionResult<List<GetProjectListDto>>> GetAllProjects()
        {
            var projects = await _mediator.Send(new GetProjectListQuery());
            return Ok(projects);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] CreateProjectCommand project)
        {
            await _mediator.Send(project);
            return Ok();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var command = new DeleteProjectCommand() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetProjectById/{id}")]
        public async Task<ActionResult<GetProjectDetailsDto>> GetProjecById(int id)
        {
            var Tasks = await _mediator.Send(new GetProjectDetailsQuery { Id = id });
            return Ok(Tasks);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateProject([FromBody] UpdateProjectCommand project)
        {

            await _mediator.Send(project);
            return Ok();

        }

        #endregion
    }
}
