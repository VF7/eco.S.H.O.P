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
    public class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(ECOshopContext ecoShopContext) : base(ecoShopContext)
        {
        }

        public async override Task<IReadOnlyCollection<Review>> FindByConditionAsync(Expression<Func<Review, bool>> predicat)
        {
            return await this.entities.Include(rev => rev.Product).
                Include(rev => rev.UserWhoReview).
                Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
