using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Commands.CreateNewUser
{
    public class CreateNewUserHandler : IRequestHandler<CreateNewUserCommand, bool>
    {
        private readonly IMediator _mediator;
        public CreateNewUserHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool Handle(CreateNewUserCommand message)
        {

            _mediator.PublishAsync(new UserDoesntExistValidator());
        }
    }
}
