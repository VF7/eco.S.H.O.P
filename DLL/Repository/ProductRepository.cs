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

        public async Task AddToOrderAsync(Product product, int orderId)
        {
            product.OrderId = orderId;
            base._ecoShopContext.Entry(product).State = EntityState.Modified;
            base._ecoShopContext.SaveChanges();
        }
        public async Task ChangeProductAsync(Product newProduct, int oldProductId)
        {
            var product = base._ecoShopContext.Products.Find(oldProductId);
            product.Category = newProduct.Category;
            product.CategoryId = newProduct.CategoryId;
            product.Photos = newProduct.Photos;
            product.Reviews = newProduct.Reviews;
            product.Employee = newProduct.Employee;
            product.EmployeeId = newProduct.EmployeeId;
            product.Order = newProduct.Order;
            product.Description = newProduct.Description;
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;

            base._ecoShopContext.Entry(product).State = EntityState.Modified;
            base._ecoShopContext.SaveChanges();
        }
        public async Task RemoveProductFromOrderAsync(int orderId, int removeProductId)
        {
            base._ecoShopContext.Orders.Find(orderId).Product.Remove(base._ecoShopContext.Orders.Find(orderId).Product.Where(x=>x.Id==removeProductId).First());
        }

        public async Task CompleteOrderAsync(int userId, int orderId)
        {
            
        }
    }
}
