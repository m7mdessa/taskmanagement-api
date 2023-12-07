using MediatR;



namespace Application.Queries.DeveloperQueries.GetDeveloperList
{
    public record GetDeveloperListQuery : IRequest<List<GetDeveloperListDto>>;


}
