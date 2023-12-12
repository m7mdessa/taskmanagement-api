using Domain.Aggregates.ProjectAggregate;
using FluentValidation;

namespace Application.Commands.SprintCommands.CreateSprint

{
    public class CreateSprintCommandValidator : AbstractValidator<CreateSprintCommand>
    {

        private readonly IProjectRepository _projectRepository;

        public CreateSprintCommandValidator(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            RuleFor(p => p.ProjectId)
               .NotNull()
               .MustAsync(ProjectMustExist)
               .WithMessage("{PropertyName} must be present");

            RuleFor(p => p.SprintName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

           RuleFor(p => p.SprintDescription)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
             

        }
        private async Task<bool> ProjectMustExist(int id, CancellationToken arg2)
        {
            var project = await _projectRepository.GetAsync(id);
            return project != null;
        }

    }








}
