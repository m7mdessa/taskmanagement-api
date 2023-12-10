
using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;

namespace Domain.Aggregates.DeveloperAggregate
{
    public class Developer : BaseEntity, IAggregateRoot, IFullAuditedObject
    {
        public Address? Address { get; private set; }
        public string? DeveloperName { get; private set; }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        public string? Email { get; private set; }
        public bool IsDeleted { get; private set; }

        public List<UserLogin> UserLogins { get; private set; } = new List<UserLogin>();


        private Developer() {}
      

        public Developer(int id, string? firstName, string? lastName, string? email, Address address,string? developerName, string? password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            DeveloperName = developerName;

            AddUserLogin(developerName, password, 3, id);
        }


        public void UpdateDeveloper(int id,string? firstName, string? lastName, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
          
        }

        public void UpdatePassword(int developerId, string? password)
        {
            var update = UserLogins?.FirstOrDefault(s => s.DeveloperId == developerId);

            if (update != null)
            {

                update.Update(developerId, password);
            }
        }

     
        public void AddUserLogin(string? userName, string? password, int roleId, int developerId)
        {
            var userLogin = new UserLogin(userName, password, roleId, developerId);

            UserLogins.Add(userLogin);
        }

        
    }
}
