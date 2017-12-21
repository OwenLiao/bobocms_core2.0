using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using bobo.orm.efcore;
using Autofac.Multitenant;
using Autofac;
using bobo.Service;
using bobo.IService;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Castle.DynamicProxy;
using AutofacContrib.DynamicProxy;

namespace bobo.web
{
    public class Startup
    {


        #region Autofac×¢²á

        public class AopInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {

            }
        }
        public IContainer ApplicationContainer { get; private set; }

        private IServiceProvider RegisterAutofac(IServiceCollection services)
        {
            // var assembly = this.GetType().GetTypeInfo().Assembly;
            Assembly assembly = Assembly.Load(new AssemblyName("bobo.Service"));
            var builder = new ContainerBuilder();
            var manager = new ApplicationPartManager();

            manager.ApplicationParts.Add(new AssemblyPart(assembly));
            manager.FeatureProviders.Add(new ControllerFeatureProvider());

            var feature = new ControllerFeature();

            manager.PopulateFeature(feature);

            builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
            builder.Populate(services);



            builder.RegisterType<AopInterceptor>();

            builder.RegisterAssemblyTypes(assembly)
                  .Where(type =>
                         typeof(IDependency).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope()
                  .EnableInterfaceInterceptors().InterceptedBy(typeof(AopInterceptor));


            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        #endregion


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<MyDbContext>(options =>
                 options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            return RegisterAutofac(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
