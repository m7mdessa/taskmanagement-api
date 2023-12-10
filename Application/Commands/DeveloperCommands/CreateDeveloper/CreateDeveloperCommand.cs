using MediatR;


namespace Application.Commands.DeveloperCommands.CreateDeveloper
{
    public class CreateDeveloperCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }

        public string? Street { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get;  set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }
}
