using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Commands.CreateNewUser
{
    public class CreateNewUserHandler : IAsyncRequestHandler<CreateNewUserCommand, bool>
    {
        public CreateNewUserHandler()
        {
        }


        Task<bool> IAsyncRequestHandler<CreateNewUserCommand, bool>.Handle(CreateNewUserCommand message)
        {
            return Task.FromResult(true);
        }
    }
}
