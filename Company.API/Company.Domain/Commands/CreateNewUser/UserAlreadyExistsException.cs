﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Commands.CreateNewUser
{
    public class UserAlreadyExistsException : Exception
    {
        public override string Message
        {
            get
            {
                return "A user with that email address already exists";
            }
        }
    }
}
