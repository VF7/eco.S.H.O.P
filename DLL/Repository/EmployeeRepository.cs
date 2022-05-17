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
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(ECOshopContext ecoShopContext) : base(ecoShopContext)
        {
        }

        public override async Task<IReadOnlyCollection<Employee>> FindByConditionAsync(Expression<Func<Employee, bool>> predicat)
        {
            return await this.entities.Include(empl => empl.UserInfo).
                Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
