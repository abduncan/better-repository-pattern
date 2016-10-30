using MediatR;

namespace Company.Domain.Commands.CreateNewUser
{
    public class CreateNewUserCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
