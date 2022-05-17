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
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(ECOshopContext ecoShopContext) : base(ecoShopContext)
        {
        }

        public async override Task<IReadOnlyCollection<Product>> FindByConditionAsync(Expression<Func<Product, bool>> predicat)
        {
            return await this.entities
                .Include(prod => prod.Category)
                .Include(prod => prod.Employee)
                .Include(prod => prod.Order)
                .Include(prod => prod.Photos)
                .Include(prod => prod.Reviews)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async override Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            return await this.entities
                .Include(prod => prod.Category)
                .Include(prod => prod.Employee)
                .Include(prod => prod.Order)
                .Include(prod => prod.Photos)
                .Include(prod => prod.Reviews)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
