using Domain.SharedKernel;

namespace Domain.Aggregates.DeveloperAggregate
{
    public interface IDeveloperRepository : IGenericRepository<Developer>
    {
        Task<Developer> GetDeveloperChildsAsync(int developerId);


    }


}
