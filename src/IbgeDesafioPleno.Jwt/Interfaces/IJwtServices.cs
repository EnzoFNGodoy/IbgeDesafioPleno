using IbgeDesafioPleno.Domain.Entities;

namespace IbgeDesafioPleno.Jwt.Interfaces;

public interface IJwtServices
{
    string GenerateToken(User user);
}