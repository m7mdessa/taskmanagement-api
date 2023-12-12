
using Domain.SharedKernel;
using System.Linq.Expressions;

namespace Domain.Aggregates.ProjectAggregate
{
    public interface IProjectRepository : IGenericRepository<Project>
    {

        Task<Project> GetProjectChildsAsync(int projectId);

        Task<Project> GetDeveloperTasksAsync(int projectId, int developerId);

        Task SoftDeleteSprintTaskAsync(int projectId, int sprintId, int sprintTaskId);
    }
}
