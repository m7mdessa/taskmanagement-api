
using Domain.SharedKernel;
using System.Linq.Expressions;

namespace Domain.Aggregates.ProjectAggregate
{
    public interface IProjectRepository : IGenericRepository<Project>
    {

        Task<Project> GetProjectChildsAsync(int projectId);
    }
}
