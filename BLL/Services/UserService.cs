using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services
{
    public class UserService:IUserService, IEmployeeService
    {
        private readonly UserRepository _userRepository;
        private readonly UserInfoRepository _userInfoRepository;
        private readonly ProductRepository _productRepository;
        public UserService( ProductRepository productRepository, UserInfoRepository userInfoRepository)
        {
     
            _productRepository = productRepository;
            _userInfoRepository = userInfoRepository;
        }

        public async Task AddProductAsync(Product product, int employeeId)
        {
            product.EmployeeId = employeeId;
            await _productRepository.CreateAsync(product);
        }
        public async Task AddUserInfoAsync(UserInfo userInfo)
        {
            await _userInfoRepository.CreateAsync(userInfo);
        }

        public async Task AddToOrderAsync(Product product, int orderId)
        {
            await _productRepository.AddToOrderAsync(product, orderId);
        }

        public async Task ChangeProductAsync(Product newProduct, int oldProductId)
        {
            await _productRepository.ChangeProductAsync(newProduct, oldProductId);
        }

        public async Task RemoveProductFromOrderAsync(int orderId, int removeProductId)
        {
            await _productRepository.RemoveProductFromOrderAsync(orderId, removeProductId);
        }

        public async Task CompleteOrderAsync(int userId, int orderId)
        {
            await _productRepository.CompleteOrderAsync(userId, orderId);
        }
    }
}
