﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Commands.CreateNewUser
{
    class UserDoesntExistHandler : IAsyncNotificationHandler<UserDoesntExistValidator>
    {
        public Task Handle(UserDoesntExistValidator notification)
        {
            throw new NotImplementedException();
        }
    }
}