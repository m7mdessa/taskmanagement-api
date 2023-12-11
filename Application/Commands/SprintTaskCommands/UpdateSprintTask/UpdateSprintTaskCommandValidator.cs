using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using FluentValidation;


namespace Application.Commands.SprintTaskCommands.UpdateSprintTask
{
   
    public class UpdateSprintTaskCommandValidator : AbstractValidator<UpdateSprintTaskCommand>
    {

        private readonly IProjectRepository _projectRepository;

        public UpdateSprintTaskCommandValidator(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

                    


        }
        private async Task<bool> ProjectMustExist(int id, CancellationToken arg2)
        {
            var project = await _projectRepository.GetAsync(id);
            return project != null;
        }

    }
}
