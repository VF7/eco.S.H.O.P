using DLL.Context;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Repository;

namespace BLL.Infrastructure
{
    public static class Configuration
    {
        public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString, IdentityBuilder builder)
        {
            serviceCollection.AddDbContext<ECOshopContext>(options =>
    options.UseSqlServer(connectionString, x=>x.MigrationsAssembly("DLL")));

           builder.AddEntityFrameworkStores<ECOshopContext>();


           //Repository
           builder.Services.AddTransient<UserRepository>();
           builder.Services.AddTransient<UserInfoRepository>();
           builder.Services.AddTransient<EmployeeRepository>();
           builder.Services.AddTransient<ProductRepository>();
        }
    }
}
