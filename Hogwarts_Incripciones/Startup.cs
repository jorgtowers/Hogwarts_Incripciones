using Hogwarts_Incripciones.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts_Incripciones
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
            services.AddControllers();

            #region Swagger Init            

            services.AddSwaggerGen(opts => 
                opts.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()    
                {
                     Title="RESTApi Hogwarts",
                     Version="1.0.0",
                     Contact= new Microsoft.OpenApi.Models.OpenApiContact()
                     {
                         Name = "Jorge L. Torres A.",
                         Email = "jorgtowers@gmail.com",
                         Url = new Uri("https://jorgtowers.github.com")
                     }
                }));
            
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger Options
            SwaggerOptions swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(opts => opts.RouteTemplate = swaggerOptions.PathJson);
            app.UseSwaggerUI(opts =>
            {
                opts.RoutePrefix = swaggerOptions.RoutePrefix;
                opts.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            }); 

            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
