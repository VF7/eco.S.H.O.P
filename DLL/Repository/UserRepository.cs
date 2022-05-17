using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ECOshopContext ecoShopContext) : base(ecoShopContext)
        {
        }

        public async override Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await this.entities.Include(use => use.UserInfo).
                Include(use => use.Orders).
                Include(use => use.Reviews).
                Include(use => use.Products).
                Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
