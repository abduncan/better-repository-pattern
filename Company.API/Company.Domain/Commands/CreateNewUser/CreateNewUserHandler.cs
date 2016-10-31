using Company.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Commands.CreateNewUser
{
    public class CreateNewUserHandler : IAsyncRequestHandler<CreateNewUserCommand, User>
    {
        public CreateNewUserHandler()
        {
        }

        public Task<User> Handle(CreateNewUserCommand message)
        {
            return Task.FromResult(new User());
        }

    }
}
