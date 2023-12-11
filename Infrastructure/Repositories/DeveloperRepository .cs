using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{


    public class DeveloperRepository : RepositoryBase<Developer>, IDeveloperRepository
    {

        public DeveloperRepository(TaskManagementContext context) : base(context) { }
        public async Task<Developer> GetDeveloperChildsAsync(int developerId)
        {
            return await _context.Developers
                .Include(p => p.UserLogins)
                    .ThenInclude(s => s.Role)
                .FirstOrDefaultAsync(p => p.Id == developerId);
        }


    }
}

