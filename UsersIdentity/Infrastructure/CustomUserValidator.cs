using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UsersIdentity.Models;

namespace UsersIdentity.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(AppUserManager manager) : base(manager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            var result = await base.ValidateAsync(user);
            if (!user.Email.ToLower().EndsWith("@example.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("only example.com email address are allowed");
                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}