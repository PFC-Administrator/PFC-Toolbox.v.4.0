using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;

[assembly: OwinStartupAttribute(typeof(PFC_Toolbox.v._4._0.Startup))]
namespace PFC_Toolbox.v._4._0
{
    public partial class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //Custom password hasher that stores in plain text; yes, it's a bad idea. Allows for easy import of new users directly from SMS without
        //the bulky hashing of each password.
        public class ClearPassword : IPasswordHasher
        {
            public string HashPassword(string password)
            {
                return password;
            }

            public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
            {
                if (hashedPassword.Equals(providedPassword))
                    return PasswordVerificationResult.Success;
                else return PasswordVerificationResult.Failed;
            }
        }
    }
}
