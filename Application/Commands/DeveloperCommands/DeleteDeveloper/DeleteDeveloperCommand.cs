using MediatR;


namespace Application.Commands.DeveloperCommands.DeleteDeveloper
{

    public class DeleteDeveloperCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}