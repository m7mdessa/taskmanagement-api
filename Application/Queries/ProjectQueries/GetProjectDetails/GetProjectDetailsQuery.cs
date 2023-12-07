using MediatR;


namespace Application.Queries.ProjectQueries.GetProjectDetails
{
    
    public class GetProjectDetailsQuery : IRequest<GetProjectDetailsDto>
    {
        public int Id { get; set; }
    }
}
