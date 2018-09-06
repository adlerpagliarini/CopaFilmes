using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
