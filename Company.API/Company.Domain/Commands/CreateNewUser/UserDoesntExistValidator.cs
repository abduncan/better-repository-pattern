﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Threading;

namespace Company.Domain.Commands.CreateNewUser
{
    public class UserDoesntExistValidator : AbstractValidator<CreateNewUserCommand>
    {
        public override ValidationResult Validate(CreateNewUserCommand instance)
        {
            return base.Validate(instance);
        }
    }
}
