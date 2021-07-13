using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApiBase.Common;
using WebApiBase.Model;
using WebApiBase.Repository;
using WebApiBase.Service;

namespace WebApiBase
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
            //注册appsettings读取类
            services.AddSingleton(new AppSettings(Configuration));
            //注册FreeSql
            services.AddSingleton<IFreeSql>(new FreeSqlHelper().Freesql());
            //FreeSql仓储模式 提供CURD接口
            services.AddFreeRepository();
            
            services.AddControllers();
            //Swagger配置
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApiBase", Version = "v1"});
                c.OrderActionsBy(o => o.RelativePath);
            });
            services.AddAutoMapper(typeof(Startup));
            /*services.AddSingleton<StudentService>();
            services.AddSingleton<StudentRepository>();*/
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service")).SingleInstance();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Repository")).SingleInstance();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiBase v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}