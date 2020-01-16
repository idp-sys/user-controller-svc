using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using UserManager.Application.Services;
using UserManager.Domain.Interfaces.Repositories;
using UserManager.Domain.Interfaces.Services;
using UserManager.Infra.CrossCutting.Identity.Config;
using UserManager.Infra.CrossCutting.Identity.Context;
using UserManager.Infra.CrossCutting.Identity.Model;
using UserManager.Infra.CrossCutting.Identity.Repositories;

namespace UserManager.API
{
    public class Startup
    {
        private Container container = new Container();

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            container.Options.ResolveUnregisteredConcreteTypes = false;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //Registrando Container IoC
            // Sets up the basic configuration that for integrating Simple Injector with
            // ASP.NET Core by setting the DefaultScopedLifestyle, and setting up auto
            // cross wiring.
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and
                // allows request-scoped framework services to be resolved.
                options.AddAspNetCore()
                       .AddControllerActivation();
                options.AddLogging();
            });

            services.UseSimpleInjectorAspNetRequestScoping(container);

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Manager API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            app.UseSimpleInjector(container);
            InitializeContainer(container);

            container.Verify();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();
        }

        private void InitializeContainer(Container container)
        {
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);

            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);

            container.Register<ApplicationUserManager>(Lifestyle.Scoped);

            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);

            container.Register<IUserService, UserService>(Lifestyle.Scoped);
        }
    }
}