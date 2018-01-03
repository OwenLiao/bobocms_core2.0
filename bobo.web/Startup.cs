using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using bobo.IService;
using Autofac.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection.Extensions;
using bobo.orm.efcore;
using Microsoft.EntityFrameworkCore;
using bobo.Service;
using AutofacDemo.Codes;

namespace Bobo.Web
{
    public class Startup
    {



        #region Autofac注册

     /*   public class AopInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {

            }
        }
        public IContainer ApplicationContainer { get; private set; }

        private IServiceProvider RegisterAutofac(IServiceCollection services)
        {
            var assembly1 = this.GetType().GetTypeInfo().Assembly;
            var assembly2 = Assembly.Load(new AssemblyName("bobo.Service"));
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(assembly1);
            assemblies.Add(assembly2);



            var builder = new ContainerBuilder();
            var manager = new ApplicationPartManager();

            manager.ApplicationParts.Add(new AssemblyPart(assembly1));
            manager.FeatureProviders.Add(new ControllerFeatureProvider());

            var feature = new ControllerFeature();

            manager.PopulateFeature(feature);

            builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
            builder.Populate(services);



            builder.RegisterType<AopInterceptor>();


            builder.RegisterAssemblyTypes(assembly1, assembly2)
                  .Where(type =>
                         typeof(IDependency).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope()
                  .EnableInterfaceInterceptors().InterceptedBy(typeof(AopInterceptor));


            this.ApplicationContainer = builder.Build();


            return new AutofacServiceProvider(this.ApplicationContainer);
        }
        */
        #endregion



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region autofac 注入容器



        /// <summary>
        /// 这里修改了ConfigureServices函数，加入返回值IServiceProvider，返回Autofac的ServiceProvider
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    // Add framework services.
        //    services.AddApplicationInsightsTelemetry(Configuration);
        //    services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

        //    services.AddMvc();
        //    services.AddDbContext<MyDbContext>(options =>
        //       options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));


        //    return RegisterAutofac(services);
        //}
        #endregion


        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            services.AddMvc();

            services.AddDbContext<MyDbContext>(options =>
                  options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            // Register application services.
            // services.AddScoped<ICharacterRepository, CharacterRepository>();
            // services.AddTransient<IOperationTransient, Operation>();
            // services.AddSingleton<IOperationSingleton, Operation>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserManager, UserManager>();


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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
