
using Domain.SharedKernel;


namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagementContext _context;

        public UnitOfWork(TaskManagementContext context)
        {
            _context = context;
        }

      

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}