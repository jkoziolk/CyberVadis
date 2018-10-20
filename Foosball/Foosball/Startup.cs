using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foosball.DataManagers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Foosball.DbModels;

namespace Foosball
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
            services.AddMvc();
            //connection string should be moved to the configuration file in the next step.
            var connection = @"Server=localhost\SQLExpress;Database=CyberVadisFoosball;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<FoosballContext>
                (options => options.UseSqlServer(connection));
            services.AddTransient<IGamesStorage, GamesStorage>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
