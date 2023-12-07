namespace Application.Queries.DeveloperQueries.GetDeveloperList
{
    public class GetDeveloperListDto
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? DeveloperName { get; set; }
        public string? Password { get; set; }

        public string? City { get; set; }

        public string? RoleName { get; set; }

    }
}
