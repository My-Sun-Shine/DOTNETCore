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

        /// <summary>
        /// 中间件注册的顺序很重要，注册的顺序就是http经过的顺序
        /// IApplicationBuilder在Program.cs中的CreateDefaultBuilder方法进行注册
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
             * 通过变量 ASPNETCORE_ENVIRONMENT 判断是否为开发环境，还是其他环境
             * IsEnvironment(变量值)方法判断自定义的变量值
             */
            if (env.IsDevelopment())
            {
                //一、异常页中间件：开发环境抛异常的时候，转到一个显示错误信息的页面
                app.UseDeveloperExceptionPage();
            }

            //四、静态资源中间件：css，js，html，只有十一该中间件，才能访问静态文件
            app.UseStaticFiles();

            //app.UseHttpsRedirection();//将http请求转换为https请求
            //app.UseAuthentication();//验证中间件，必须在端点中间件前面
            
            /*
             * 二、路由中间件：检测已经注册的端点
             * 端点：进来的http请求的url结尾的那部分，这部分会被中间件进行处理
             */
            app.UseRouting();

            /*
             * 三、端点中间件
             */
            app.UseEndpoints(endpoints =>
            {
                //1.表示端点为/的时候，返回
                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/

                //2.MVC的路由表模板
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                //3.MVC在controller和action上使用注解的注册路由模板
                //endpoints.MapControllers();
            });
        }
    }
}
