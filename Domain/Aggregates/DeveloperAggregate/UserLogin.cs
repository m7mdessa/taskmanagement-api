using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.DeveloperAggregate
{
    public class UserLogin:BaseEntity , IFullAuditedObject
    {

        public string? UserName { get;private set; }

        public string? Password { get; private set; }

        public int RoleId { get; private set; }

        public int? DeveloperId { get; private set; }

        public  Developer? Developer { get; private set; }

        public  Role? Role { get; private set; }

        public bool IsDeleted { get; private set; }

        private UserLogin() { }


        public UserLogin(string? userName, string? password ,int roleId, int developerId )
        {

            UserName = userName;
            Password = password;
            RoleId = roleId;
            DeveloperId = developerId;


        }
        public void Update(int developerId, string? password)
        {
            Password = password;
            DeveloperId = developerId;

        }

      
    }
}
