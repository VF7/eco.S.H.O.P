using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Models;

namespace DLL.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<OperationDetail> CancelOrder();
    }
}
