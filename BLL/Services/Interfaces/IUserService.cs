using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task AddToOrderAsync(Product product, int orderId);
        Task RemoveProductFromOrderAsync( int orderId, int removeProductId);
        
    }
}
