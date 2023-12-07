using Domain.SharedKernel;

namespace Domain.SharedKernel
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

    }
}