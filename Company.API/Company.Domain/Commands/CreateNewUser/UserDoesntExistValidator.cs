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
    public class UserDoesntExistValidator : AbstractValidator<CreateNewUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserDoesntExistValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public override ValidationResult Validate(CreateNewUserCommand instance)
        {

            // Verify that the user doesn't exist
            User user = _userRepository.GetUserByEmail(instance.Email);

            // The user is attempting to create a user with an email address
            // that already exists.
            if (user != null)
                throw new UserAlreadyExistsException();

            return new ValidationResult();
        }

        public override ValidationResult Validate(ValidationContext<CreateNewUserCommand> context)
        {
            return Validate(context.InstanceToValidate);
        }
    }
}
