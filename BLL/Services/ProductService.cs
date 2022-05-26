using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyCollection<Product>> FindByConditionAsync(Expression<Func<Product, bool>> predicat)
            => await _productRepository.FindByConditionAsync(predicat);


        //public async Task<List<Product>> FindByIdAsync(int Id)
        //    => (await _productRepository.FindByConditionAsync(x => x.Id == Id)).First();
    }
}
