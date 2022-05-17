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
    public class UserInfoRepository : BaseRepository<UserInfo>
    {
        public UserInfoRepository(ECOshopContext ecoShopContext) : base(ecoShopContext)
        {
        }

        public async override Task<IReadOnlyCollection<UserInfo>> FindByConditionAsync(Expression<Func<UserInfo, bool>> predicat)
        {
            return await this.entities.Include(userInf => userInf.Photo).
                Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
