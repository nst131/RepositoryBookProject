using Application.Exceptions;
using Application.Interfaces;
using Domain;
using EFData.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Registration
{
    public class RegistrationHandler : IRegistrationHandler
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IJwtGenerator jwtGenerator;

        public RegistrationHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IJwtGenerator jwtGenerator)
        {
            this.userManager = userManager;
            this.jwtGenerator = jwtGenerator;
            this.roleManager = roleManager;
        }

        public async Task<Application.User.User> Registration(RegistrationQuery request)
        {
            var registrationQueryValidation = new RegistrationQueryValidation(roleManager);
            var resultRegistrationQueryValidation = await registrationQueryValidation.ValidateAsync(request);

            if (!resultRegistrationQueryValidation.IsValid)
                throw new RestException(HttpStatusCode.Unauthorized,
                    resultRegistrationQueryValidation.Errors.ToList().FirstOrDefault()?.ErrorMessage);

            var user = new AppUser { UserName = request.Name, Email = request.Email };

            var resultAppendUser = await userManager.CreateAsync(user, request.Password);

            if (!resultAppendUser.Succeeded)
                throw new RestException(HttpStatusCode.BadRequest, $"Can't append {nameof(AppUser)}");

            var resultAppendRole = await userManager.AddToRoleAsync(user, request.Role ?? Roles.User.ToString());

            if (resultAppendRole.Succeeded)
                return new Application.User.User() { Token = await jwtGenerator.CreateToken(user) };

            throw new RestException(HttpStatusCode.BadRequest, $"Can't append {nameof(request.Role)}");
        }
    }
}

