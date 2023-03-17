using Domain;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJwtGenerator
    {
        Task<string> CreateToken(AppUser user);
    }
}
