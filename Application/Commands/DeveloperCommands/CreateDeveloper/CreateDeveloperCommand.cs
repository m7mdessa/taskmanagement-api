using MediatR;


namespace Application.Commands.DeveloperCommands.CreateDeveloper
{
    public class CreateDeveloperCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? City { get; private set; }

        public string? Street { get; private set; }

        public string? State { get; private set; }

        public string? Country { get; private set; }

        public string? ZipCode { get; private set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }
}
