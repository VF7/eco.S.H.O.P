using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        IAsyncResult Index();
        Task<IAsyncResult> AddProductAsync(Product product, int employeeId);
       // Task<List<Product>> FindByIdAsync(int Id);
    }
}
