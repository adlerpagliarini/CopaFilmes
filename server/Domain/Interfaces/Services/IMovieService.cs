using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IMovieService : IServiceBase<Movie>
    {
        IEnumerable<Movie> GetByIds(IList<string> ids);
    }
}
