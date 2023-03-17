using System.Threading.Tasks;

namespace Application.Registration
{
    public interface IRegistrationHandler
    {
        Task<User.User> Registration(RegistrationQuery request);
    }
}
