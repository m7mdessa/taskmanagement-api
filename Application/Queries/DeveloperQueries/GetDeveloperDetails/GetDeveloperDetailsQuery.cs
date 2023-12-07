using MediatR;


namespace Application.Queries.DeveloperQueries.GetDeveloperDetails
{
  
    public class GetDeveloperDetailsQuery : IRequest<GetDeveloperDetailsDto>
    {
        public int Id { get; set; }
    }
}
