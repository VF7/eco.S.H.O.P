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
        private readonly ReviewRepository _reviewRepository;
        private readonly OrderRepository _orderRepository;
        public ProductService(ProductRepository productRepository, OrderRepository orderRepository, ReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _orderRepository = orderRepository;
        }

        public async Task<IReadOnlyCollection<Product>> FindByConditionAsync(Expression<Func<Product, bool>> predicat)
            => await _productRepository.FindByConditionAsync(predicat);

        //public IAsyncResult AddProduct() => View();
        //public async Task<IAsyncResult> Index()
        //{
        //    return View();
        //}

        IAsyncResult IProductService.Index()
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncResult> AddProductAsync(Product product, int employeeId)
        {
            throw new NotImplementedException();
        }


        //public async Task<List<Product>> FindByIdAsync(int Id)
        //    => (await _productRepository.FindByConditionAsync(x => x.Id == Id)).First();
    }
}
