using Application.Auth;
using Application.Commands.DeveloperCommands.CreateDeveloper;
using Application.Commands.DeveloperCommands.DeleteDeveloper;
using Application.Commands.DeveloperCommands.DeleteUserLogin;
using Application.Commands.DeveloperCommands.UpdateDeveloper;
using Application.Commands.DeveloperCommands.UpdatePassword;
using Application.Queries.DeveloperQueries.GetDeveloperDetails;
using Application.Queries.DeveloperQueries.GetDeveloperList;
using Application.Queries.DeveloperQueries.GetUserLoginDetails;
using Application.Queries.DeveloperQueries.GetUserLoginList;
using Application.Queries.SprintTaskQueries.GetDeveloperSprintTaskList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public partial class DevelopersController : ControllerBase
    {
        #region Developers

        private readonly IMediator _mediator;
        private readonly IAuthService _authService;


        public DevelopersController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;

        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<ActionResult<List<GetDeveloperListDto>>> GetAllDevelopers()
        {
            var developers = await _mediator.Send(new GetDeveloperListQuery());
            return Ok(developers);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult> CreateDeveloper([FromBody] CreateDeveloperCommand developer)
        {
            bool usernameExists = _authService.IsUsernameTaken(developer.UserName);
            bool emailExists = _authService.IsEmailTaken(developer.Email);

            if (usernameExists)
            {
                return Conflict(new { error = "developer name already exists" });
            }
            else if (emailExists)
            {
                return Conflict(new { error = "email already exists" });
            }

            await _mediator.Send(developer);
            return Ok();
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteDeveloper(int id)
        {
            var command = new DeleteDeveloperCommand() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetDeveloperById/{id}")]
        public async Task<ActionResult<GetDeveloperDetailsDto>> GetDeveloperById(int id)
        {
            var developer = await _mediator.Send(new GetDeveloperDetailsQuery { Id = id });
            return Ok(developer);
        }

    


        [Authorize(Policy = "DeveloperOnly")]
        [HttpGet("Project/{projectId}/DeveloperTask/{developerId}")]
        public async Task<ActionResult<GetDeveloperSprintTaskListDto>> GetDeveloperTask(int projectId, int developerId)
        {
            var developerTask = await _mediator

           .Send(new GetDeveloperSprintTaskListQuery
           {
               ProjectId = projectId,

               DeveloperId = developerId
           });
            return Ok(developerTask);
        }


        [Authorize(Policy = "DeveloperOnly")]
        [HttpGet("GetProfile/{id}")]
        public async Task<ActionResult<GetDeveloperDetailsDto>> GetProfile(int id)
        {
            var developer = await _mediator.Send(new GetDeveloperDetailsQuery { Id = id });
            return Ok(developer);
        }


        [Authorize(Policy = "DeveloperOnly")]
        [HttpPut("UpdateProfile")]
        public async Task<ActionResult> UpdateProfile([FromBody] UpdateDeveloperCommand developer)
        {

            await _mediator.Send(developer);
            return Ok();

        }

        [Authorize(Policy = "DeveloperOnly")]
        [HttpPut("UpdatePassword")]
        public async Task<ActionResult> UpdatePassword([FromBody] UpdatePasswordCommand password)
        {

            await _mediator.Send(password);
            return Ok();

        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateDeveloper([FromBody] UpdateDeveloperCommand developer)
        {

            await _mediator.Send(developer);
            return Ok();


        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("Developer/{id}/UserLogins")]
        public async Task<ActionResult<List<GetUserLoginListDto>>> GetAllUserLogins(int id)
        {
            var userLogins = await _mediator.Send(new GetUserLoginListQuery { Id = id });
            return Ok(userLogins);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("UserLogin/{developerId}")]
        public async Task<ActionResult<GetUserLoginDetailsDto>> GetUserLoginById( int developerId)
        {
            var userLogin = await _mediator
           .Send(new GetUserLoginDetailsQuery
           {
               DeveloperId = developerId,

           }

            );
            return Ok(userLogin);
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("DeleteUserLogin/{developerId}")]
        public async Task<ActionResult> DeleteUserLogin(int developerId)
        {
            var command = new DeleteUserLoginCommand() { DeveloperId = developerId };

            await _mediator.Send(command);
            return Ok();
        }


        #endregion


    }
}
