using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ecad.domain.MusicContext.Handlers;
using ecad.domain.MusicContext.Repositories;
using ecad.infra.CrudMusicContext;
using ecad.infra.CrudMusicContext.Repositories;
using ecad.shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ecad.api
{
    public class Startup
    {

        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            services.AddCors();

            services.AddMvc();
            services.AddScoped<EcadDataContext, EcadDataContext>();
            services.AddTransient<IMusicRepository, MusicRepository>();
            services.AddTransient<MusicHandler, MusicHandler>();

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<AuthorHandler, AuthorHandler>();

             services.AddTransient<IMusicAuthorRepository, MusicAuthorRepository>();
            services.AddTransient<MusicAuthorHandler, MusicAuthorHandler>();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info { Title = "API Ecad", Version = "V1" });
            });


            Settings.ConnectionString = $"{Configuration["connectionString"]}";

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();

            app.UseMvc();
            app.UseSwagger();
            //app.UseSwaggerUI(x => {
            //    x.SwaggerEndpoint("/swagger/v1/swagger.json", "API Ecad - V1");
            //});
        }
    }
}
