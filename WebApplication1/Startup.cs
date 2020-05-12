using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        /// <summary>
        /// 在该方法中注册服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region 注册系统服务
            //services.AddMvc();//使用该方法太庞大
            //对控制器、API 相关功能和视图（而不是页）的支持
            services.AddControllersWithViews();
            //只对控制器，做API的时候
            //services.AddControllers();
            #endregion

            #region 注册自定义服务

            //单例模式注册服务
            //每当请求IClock接口的时候，返回ChinaClock的实例
            services.AddSingleton<IClock, ChinaClock>();
            //HomeController使用IClock接口接收，解耦合
            //services.AddSingleton<IClock, UTCClock>();
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
