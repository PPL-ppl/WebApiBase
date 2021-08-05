using System.Reflection;
using System.Text;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApiBase.Common;
using WebApiBase.Model;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var secretByte =
                    Encoding.UTF8.GetBytes(AppSettings.app(new string[] { "AppSettings", "JwtSetting", "SecretKey" }));
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = AppSettings.app(new string[] { "AppSettings", "JwtSetting", "issuer" }),
                    ValidateAudience = true,
                    ValidAudience = AppSettings.app(new string[] { "AppSettings", "JwtSetting", "audience" }),
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretByte)
                };
            });
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiBase", Version = "v1" });
                c.OrderActionsBy(o => o.RelativePath);
            });
            services.AddAutoMapper(typeof(Startup));
            //添加cors 服务
            services.AddCors(options =>
                options.AddPolicy(AppSettings.app(new string[] { "AppSettings", "Cors", "Name" }),
                    p => p.WithOrigins(AppSettings.app(new string[] { "AppSettings", "Cors", "Original" }))
                        .AllowAnyMethod().AllowAnyHeader()));
            //注入Message类
            services.AddSingleton<Message>();
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

            app.UseCors(AppSettings.app(new string[] { "AppSettings", "Cors", "Name" }));
            app.UseHttpsRedirection();
            //路由
            app.UseRouting();
            //认证
            app.UseAuthentication();
            //授权
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}