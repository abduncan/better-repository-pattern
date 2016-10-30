using Company.Domain.Commands.CreateNewUser;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Company.API.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        public async Task<bool> Get()
        {
            return await _mediator.SendAsync(new CreateNewUserCommand() { Email = "test@email.com" });
        }
        
    }
}
