using MediatR;

namespace Company.Domain.Commands.CreateNewUser
{
    public class CreateNewUserCommand : IAsyncRequest<bool>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
