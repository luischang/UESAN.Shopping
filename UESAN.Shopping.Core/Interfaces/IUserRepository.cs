using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SignIn(string email, string password);
        Task<bool> SignUp(User user);
        Task<bool> IsEmailRegistered(string email);
    }
}