using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace eMMA.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class eMMARepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<eMMADbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected eMMARepositoryBase(IDbContextProvider<eMMADbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Add your common methods for all repositories
        public abstract IQueryable<TEntity> GetAll();
        public abstract TEntity GetSingle(TPrimaryKey personId);
        public abstract IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        public abstract void Add(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract void Edit(TEntity entity);
        public abstract void Save();
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="eMMARepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class eMMARepositoryBase<TEntity> : eMMARepositoryBase<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        protected eMMARepositoryBase(IDbContextProvider<eMMADbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
