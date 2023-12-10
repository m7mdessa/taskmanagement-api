using Application.Commands.SprintTaskCommands.CreateSprintTask;
using Application.Commands.SprintTaskCommands.DeleteSprintTask;
using Application.Commands.SprintTaskCommands.UpdateSprintTask;
using Application.Queries.SprintTaskQueries.GetDeveloperSprintTaskList;
using Application.Queries.SprintTaskQueries.GetSprintTaskDetails;
using Application.Queries.SprintTaskQueries.GetSprintTaskList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public partial class ProjectsController : ControllerBase
    {
        [HttpGet("Project/{id}/SprintTasks")]
        public async Task<ActionResult<List<GetSprintTaskListDto>>> GetAllSprintTasks(int id)
        {
            var sprintTasks = await _mediator.Send(new GetSprintTaskListQuery { Id = id });
            return Ok(sprintTasks);
        }

        [HttpPost("Project/CreateSprintTask")]
        public async Task<ActionResult> CreateSprintTask([FromBody] CreateSprintTaskCommand sprintTask)
        {
            await _mediator.Send(sprintTask);
            return Ok();
        }


        [HttpDelete("Projects/{projectId}/Sprints/{sprintId}/SprintTask/Delete/{sprintTaskId}")]
        public async Task<IActionResult> DeleteSprintTask(int sprintId, int sprintTaskId, int projectId)
        {
            var deleteSprintTaskCommand = new DeleteSprintTaskCommand
            {
                SprintId = sprintId,
                ProjectId = projectId,
                SprintTaskId = sprintTaskId
            };

            await _mediator.Send(deleteSprintTaskCommand);

            return Ok();
        }

      

        [HttpGet("Project/{projectId}/SprintTask/{id}")]
        public async Task<ActionResult<GetSprintTaskDetailsDto>> GetSprintTaskById(int id, int projectId)
        {
            var sprintTask = await _mediator

           .Send(new GetSprintTaskDetailsQuery
           {
               ProjectId = projectId,

               Id = id
           });
            return Ok(sprintTask);
        }

        [HttpPut("Project/SprintTask/Update")]
        public async Task<ActionResult> UpdateSprintTask([FromBody] UpdateSprintTaskCommand sprintTask)
        {

            await _mediator.Send(sprintTask);
            return Ok();

        }
    }
}
