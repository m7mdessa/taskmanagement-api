using MediatR;


namespace Application.Queries.ProjectQueries.GetProjectList
{

    public record GetProjectListQuery : IRequest<List<GetProjectListDto>>;

}
