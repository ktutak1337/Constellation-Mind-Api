using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ConstellationMind.Infrastructure.IoC;
using ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces;
using FluentValidation.AspNetCore;
using ConstellationMind.Api.Extensions;

namespace ConstellationMind.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().AddFluentValidation();
            services.AddJwt();
            
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime,
            IMongoDbInitializer mongoDatabase)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorHandler();
            
            app.UseAuthentication();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            applicationLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
            await mongoDatabase.InitializeAsync();
        }
    }
}
