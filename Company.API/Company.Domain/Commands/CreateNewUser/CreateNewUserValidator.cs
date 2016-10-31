using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Threading;
using Company.Domain.Infrastructure.Repository.UserRepository;
using Company.Domain.Models;

namespace Company.Domain.Commands.CreateNewUser
{
    public class CreateNewUserValidator : AbstractValidator<CreateNewUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateNewUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Password).NotEmpty().Length(8, 20);
        }
    }
}
