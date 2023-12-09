using Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {

        public ProjectRepository(TaskManagementContext context) : base(context) { }

     
        public async Task<Project> GetProjectChildsAsync(int projectId)
        {
            return await _context.Projects
                .Include(p => p.Sprints)
                    .ThenInclude(s => s.SprintTasks)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }
        public async Task<Project> GetDeveloperTasksAsync(int projectId, int developerId)
        {
            return await _context.Projects
                .Include(p => p.Sprints)
                    .ThenInclude(s => s.SprintTasks)
                .FirstOrDefaultAsync(p => p.Id == projectId);

          
        }




    }

}
