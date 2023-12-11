using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.DeveloperQueries.GetUserLoginDetails
{
    public class GetUserLoginDetailsDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? RoleName { get; set; }
        public int RoleId { get; set; }
        public int DeveloperId { get; set; }



    }
}
