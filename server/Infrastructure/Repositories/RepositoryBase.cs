using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Infrastructure.Entities;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly HttpClient _client;
        protected readonly IOptions<ApiSettings> _apiSettings;

        public RepositoryBase(HttpClient client, IOptions<ApiSettings> apiSettings)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiSettings = apiSettings;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var response = _client.GetAsync(_apiSettings.Value.BaseURL + $"/{_apiSettings.Value.PathGet}").Result;
            response.EnsureSuccessStatusCode();
            string responseString =  response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<TEntity>>(responseString);
        }

        public IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> filter = null, Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null)
        {
            IEnumerable<TEntity> query = GetAll();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }
    }
}
