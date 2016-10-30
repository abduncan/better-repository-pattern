using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Commands.CreateNewUser
{
    public class UserDoesntExistValidator : IAsyncNotification
    {
    }
}
