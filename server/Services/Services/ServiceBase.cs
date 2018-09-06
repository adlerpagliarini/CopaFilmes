using Domain.Interfaces.Services;
using Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Services.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected IRepositoryBase<TEntity> _repository { get; }

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
