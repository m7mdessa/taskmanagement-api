using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;


namespace Application.Commands.SprintCommands.DeleteSprint
{
    public class DeleteSprintCommandHandler : IRequestHandler<DeleteSprintCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;


        public DeleteSprintCommandHandler(IProjectRepository projectRepository)
        {

            _projectRepository = projectRepository;
        }



        public async Task<Unit> Handle(DeleteSprintCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId ,s=>s.Sprints);

            if (project != null)
            {
                var sprint = project.Sprints.FirstOrDefault(s => s.Id == request.SprintId);

                if (sprint != null)
                {

                    project.RemoveSprint(sprint);

                    await _projectRepository.UpdateAsync(project);
                }
                    

               
            }

            return Unit.Value;




        }


    }
}
