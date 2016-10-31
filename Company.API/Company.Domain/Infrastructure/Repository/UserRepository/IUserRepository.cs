using Company.Domain.Models;

namespace Company.Domain.Infrastructure.Repository.UserRepository
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
    }
}