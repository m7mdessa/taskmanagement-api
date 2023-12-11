﻿using Application.Commands.SprintCommands.CreateSprint;
using Application.Commands.SprintCommands.DeleteSprint;
using Application.Commands.SprintCommands.UpdateSprint;
using Application.Queries.SprintQueries.GetSprintDetails;
using Application.Queries.SprintQueries.GetSprintList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  
    public partial class ProjectsController : ControllerBase
    {

        #region Sprints

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("Project/{id}/Sprints")]
        public async Task<ActionResult<List<GetSprintListDto>>> GetAllSprints(int id)
        {

            var sprints = await _mediator.Send(new GetSprintListQuery { Id = id });
            return Ok(sprints);
        }
        [Authorize(Policy = "AdminOnly")]

        [HttpPost("Project/CreateSprint")]
        public async Task<ActionResult> CreateSprint([FromBody] CreateSprintCommand sprint)
        {
            await _mediator.Send(sprint);
            return Ok();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("Project/{projectId}/Delete/Sprint/{sprintId}")]
        public async Task<IActionResult> DeleteSprint(int projectId, int sprintId)
        {
            var deleteSprintCommand = new DeleteSprintCommand
            {
                ProjectId = projectId,
                SprintId = sprintId
            };

            await _mediator.Send(deleteSprintCommand);

            return Ok();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("Project/{projectId}/Sprint/{id}")]
        public async Task<ActionResult<GetSprintDetailsDto>> GetSprintById(int id, int projectId)
        {
            var sprint = await _mediator
           .Send(new GetSprintDetailsQuery
           {
               ProjectId = projectId,

               Id = id
           }

            );
            return Ok(sprint);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Sprint/Update")]
        public async Task<ActionResult> UpdateSprint([FromBody] UpdateSprintCommand sprint)
        {

            await _mediator.Send(sprint);
            return Ok();

        }

        #endregion
    }
}
