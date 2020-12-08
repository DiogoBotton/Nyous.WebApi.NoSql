using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Nyous.WebApi.NoSQL.Contexts;
using Nyous.WebApi.NoSQL.Interfaces;
using Nyous.WebApi.NoSQL.Repositories;

namespace Nyous.WebApi.NoSQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Injeção de dependência para configurar o MongoDB
            services.Configure<NyousDatabaseSettings>(
            Configuration.GetSection(nameof(NyousDatabaseSettings)));

            services.AddSingleton<INyousDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<NyousDatabaseSettings>>().Value);

            // Injeção de dependência para os Repositories (vínculo entre interface e repositorio)
            services.AddSingleton<IEventosRepository, EventosRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
