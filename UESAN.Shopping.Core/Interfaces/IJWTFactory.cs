using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Settings;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IJWTFactory
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}