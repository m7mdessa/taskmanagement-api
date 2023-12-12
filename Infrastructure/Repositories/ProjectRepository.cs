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

        public async Task SoftDeleteSprintTaskAsync(int projectId, int sprintId, int sprintTaskId)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project != null)
            {
                var sprint = project.Sprints.FirstOrDefault(s => s.Id == sprintId);

                if (sprint != null)
                {
                    var sprintTask = sprint.SprintTasks.FirstOrDefault(s => s.Id == sprintTaskId && !s.IsDeleted);

                    if (sprintTask != null)
                    {
                        sprintTask.SoftDelete();
                        _context.Entry(sprintTask).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }


    }

}
