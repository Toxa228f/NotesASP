using Notes.Domain.Entities;

namespace Notes.JWT
{
    public interface IGenerateToken
    {
        string GenerateNewToken(User user);
    }
}
