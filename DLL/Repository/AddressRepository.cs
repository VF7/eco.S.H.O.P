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
    public class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(ECOshopContext ecoShopContext) : base(ecoShopContext)
        {
        }

        public async override Task<IReadOnlyCollection<Address>> FindByConditionAsync(Expression<Func<Address, bool>> predicat)
        {
            return await this.entities
                .Include(adr => adr.UserInfo)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async override Task<IReadOnlyCollection<Address>> GetAllAsync()
        {
            return await this.entities
                .Include(adr => adr.UserInfo)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
    
}
