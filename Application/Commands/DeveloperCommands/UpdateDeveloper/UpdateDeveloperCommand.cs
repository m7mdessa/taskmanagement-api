using MediatR;


namespace Application.Commands.DeveloperCommands.UpdateDeveloper
{
    public class UpdateDeveloperCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? City { get;  set; }

        public string? Street { get;  set; }

        public string? State { get;  set; }

        public string? Country { get;  set; }
        public string? ZipCode { get;  set; }

    }
}
