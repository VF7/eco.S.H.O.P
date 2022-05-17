using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;

namespace DLL.Repository
{
    public class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(ECOshopContext ecoShopContext) : base(ecoShopContext)
        {
        }
    }
}
