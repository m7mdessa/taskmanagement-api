using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeveloperCommands.DeleteUserLogin
{
 
    public class DeleteUserLoginCommand : IRequest<Unit>
    {
        public int DeveloperId { get; set; }

    }
}
