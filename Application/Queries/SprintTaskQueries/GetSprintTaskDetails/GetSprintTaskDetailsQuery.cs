using MediatR;


namespace Application.Queries.SprintTaskQueries.GetSprintTaskDetails
{
  
    public class GetSprintTaskDetailsQuery : IRequest<GetSprintTaskDetailsDto>
    {
        public int ProjectId { get; set; }
        public int Id { get; set; }
    }
}
