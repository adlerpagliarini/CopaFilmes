using Domain.Entities;
using Domain.Interfaces.Services;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class MovieService : ServiceBase<Movie>, IMovieService
    {
        public MovieService(IMovieRepository repository) : base(repository){}

        public IEnumerable<Movie> GetByIds(IList<string> ids)
        {
            return _repository.GetAllWhere(
                                    (entity => ids.Contains(entity.Id)), 
                                    (entity => entity.OrderBy(e => e.Title))
                                );
        }
    }
}
