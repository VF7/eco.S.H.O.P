using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DLL.Context;
using DLL.Models;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECOshopContext ecoShopContext) : base(ecoShopContext)
        {
        }

        public async Task<OperationDetail> CancelOrder()
        {
            throw new NotImplementedException();
        }

        public override async Task<IReadOnlyCollection<Order>> FindByConditionAsync(Expression<Func<Order, bool>> predicat)
        {
            return await this.entities
                .Include(ord=>ord.Buyer)
                .Include(ord=>ord.Address)
                .Include(ord => ord.Product)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async override Task<IReadOnlyCollection<Order>> GetAllAsync()
        {
            return await this.entities
                .Include(ord => ord.Buyer)
                .Include(ord => ord.Address)
                .Include(ord => ord.Product)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
