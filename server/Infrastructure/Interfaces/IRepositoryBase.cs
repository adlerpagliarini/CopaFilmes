using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> filter = null, Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null);
    }
}
