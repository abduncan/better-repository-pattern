using Company.Domain.Commands.CreateNewUser;
using Company.Domain.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var user = await _mediator.SendAsync(new CreateNewUserCommand()
                {
                    Email = "test@email.com",
                    Name = "andrew",
                     Password="12345678"
                });
                return Json(user);

            }
            catch (UserAlreadyExistsException userAlreadyExistsException)
            {
                return Conflict();
            }
            catch (ValidationException ex)
            {
                return BadRequest();
            }

        }

    }
}
