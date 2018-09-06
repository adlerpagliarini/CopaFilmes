using Domain.Entities;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Infrastructure.Repositories
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(HttpClient client, IOptions<ApiSettings> apiSettings) : base(client, apiSettings){}
    }
}






/*
protected readonly IConfiguration _configuration;
public MovieRepository(IConfiguration configuration)
{
    var x = _configuration.GetSection("ApiSettings:BaseURL").Value;
}
*/

