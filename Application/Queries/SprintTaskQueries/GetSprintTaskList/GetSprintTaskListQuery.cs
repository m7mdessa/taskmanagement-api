using MediatR;


namespace Application.Queries.SprintTaskQueries.GetSprintTaskList
{
    

    public class GetSprintTaskListQuery : IRequest<List<GetSprintTaskListDto>>
    {
        public int Id { get; set; }
    }

}
