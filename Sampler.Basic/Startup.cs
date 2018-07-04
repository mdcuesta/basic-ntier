using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sampler.Basic.Core;
using StructureMap;

namespace Sampler.Basic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Utilize DI Framework
            var container = new Container();

            container.Configure(config =>
            {
                var registry = new Registry();
                registry.Scan(_ =>
                {
                    _.AssembliesAndExecutablesFromApplicationBaseDirectory();

                    // Default Convention
                    _.WithDefaultConventions();

                    // Register all Dependency Configurations
                    _.AddAllTypesOf<IDependencyConfig>();

                    // Register all Initializers
                    _.AddAllTypesOf<IInitializer>();
                });
                config.AddRegistry(registry);
            });

            // Load DependencyConfigurations and Execute
            IEnumerable<IDependencyConfig> dependencyConfigs = container.GetAllInstances<IDependencyConfig>();

            foreach (IDependencyConfig dependencyConfig in dependencyConfigs)
            {
                dependencyConfig.Configure(services);
            }

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            IEnumerable<IInitializer> initializers = app.ApplicationServices.GetServices<IInitializer>();

            foreach (IInitializer initializer in initializers)
            {
                initializer.Init();
            }
        }
    }
}
