using MediatR;


namespace Application.Commands.DeveloperCommands.UpdateDeveloper
{
    public class UpdateDeveloperCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? City { get; private set; }

        public string? Street { get; private set; }

        public string? State { get; private set; }

        public string? Country { get; private set; }

        public string? ZipCode { get; private set; }

    }
}
