using BLL.Services;
using Microsoft.AspNetCore.Identity;

namespace eco.S.H.O.P.Infrastructure
{
    public class Configuration
    {
        public static void ConfigurationService(IdentityBuilder builder)
        {

            //Services
            builder.Services.AddTransient<ProductService>();
            builder.Services.AddTransient<UserService>();
 
        }
    }
}
