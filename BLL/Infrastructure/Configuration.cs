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

namespace BLL.Infrastructure
{
    public static class Configuration
    {
        public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString, IdentityBuilder builder)
        {
            serviceCollection.AddDbContext<ECOshopContext>(options =>
    options.UseSqlServer(connectionString, x=>x.MigrationsAssembly("eco.S.H.O.P")));

           builder.AddEntityFrameworkStores<ECOshopContext>();
        }
    }
}
