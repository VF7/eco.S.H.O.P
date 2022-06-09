using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DLL.Context;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DLL.Repository.Interfaces
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public BaseRepository(ECOshopContext ecoShopContext)
        {
            _ecoShopContext = ecoShopContext;
        }

        protected ECOshopContext _ecoShopContext;

        private DbSet<TEntity> _entities;
        protected DbSet<TEntity> entities => this._entities ??= _ecoShopContext.Set<TEntity>();



        public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat)
            => await this.entities.Where(predicat).ToListAsync().ConfigureAwait(false);

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
            => await this.entities.ToListAsync().ConfigureAwait(false);

        public virtual async Task<OperationDetail> CreateAsync(TEntity entity)
        {
            try
            {
                await entities.AddAsync(entity).ConfigureAwait(false);
                await _ecoShopContext.SaveChangesAsync();
                return new OperationDetail() { Message = "Created", IsCompleted = true };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Create Fatal Exception");
                return new OperationDetail() { Message = "Created Fatal Error", IsCompleted = false };
            }
        }
    }
}
