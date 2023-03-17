using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Registration
{
    public class RegistrationQueryValidation : AbstractValidator<RegistrationQuery>
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RegistrationQueryValidation(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;

            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage($"{nameof(RegistrationQuery.Email)} is not correct");
            RuleFor(x => x.Password).NotEmpty().WithMessage($"{nameof(RegistrationQuery.Password)} is not correct");
            RuleFor(x => x.Role).MustAsync(ExistRole).WithMessage($"{nameof(RegistrationQuery.Role)} is not exist");
        }

        private async Task<bool> ExistRole(string role, CancellationToken token = default)
        {
            return await roleManager.RoleExistsAsync(role);
        }
    }
}