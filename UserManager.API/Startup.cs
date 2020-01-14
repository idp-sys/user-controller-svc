using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using UserManager.Infra.CrossCutting.IoC;
using UserManager.Infra.Data.Context;

namespace UserManager.API
{
    public class Startup
    {
        private Container container = new Container();

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("UserManagerDb");

            services.AddDbContext<UserContext>(option => option.UseLazyLoadingProxies()
                                               .UseSqlServer(conn, a => a.MigrationsAssembly("UserManager.Infra.Data")));

            services.AddAutoMapper(typeof(Startup));

            //Adicao de Container IoC
            services.AddSingleton<IControllerActivator>(
                  new SimpleInjectorControllerActivator(container));

            services.AddSingleton<IViewComponentActivator>(
                   new SimpleInjectorViewComponentActivator(container));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeContainer(container);

            //container.Register<CustomMiddleware>();

            container.Verify();

            //app.Use(async (context, next) => {
            //    await container.GetInstance<CustomMiddleware>().Invoke(context, next);
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}