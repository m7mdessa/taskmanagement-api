using Domain.SharedKernel;

namespace Domain.Aggregates.DeveloperAggregate
{
    public class Role : BaseEntity, IFullAuditedObject
    {
        public string? RoleName { get; private set; }
        public bool IsDeleted { get; private set; }

        public  List<UserLogin> UserLogins { get; private set; } = new List<UserLogin>();

        private Role() { }

        public Role(string? roleName)
        {
            RoleName = roleName;
        }


    
    }

}

