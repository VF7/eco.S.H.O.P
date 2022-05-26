using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddProductAsync(Product product, int employeeId);
        Task ChangeProductAsync(Product newProduct, int oldProductId);
        Task CompleteOrderAsync(int userId, int orderId);
    }
}
