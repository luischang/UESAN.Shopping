using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(UserAuthRequestDTO userDTO);
        Task<UserAuthResponseDTO> Validate(string email, string password);
    }
}