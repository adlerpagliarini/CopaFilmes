using Domain.Interfaces.Facedes;
using Domain.Interfaces.Services;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Facedes;
using Services.Services;

namespace ApiApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DI
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IMovieRepository, MovieRepository>();

            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IMovieService, MovieService>();

            services.AddHttpClient<IMovieRepository, MovieRepository>();

            services.AddScoped<IMovieCupService, MovieCupService>();
            services.AddScoped<IGroupStageService, GroupStageService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IMoviesCup, MoviesCup>();

            // API CONFIG
            var appSettingsSection = Configuration.GetSection("ApiSettings");
            services.Configure<ApiSettings>(appSettingsSection);

            // Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
