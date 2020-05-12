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
        /// �ڸ÷�����ע�����
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region ע��ϵͳ����
            //services.AddMvc();//ʹ�ø÷���̫�Ӵ�
            //�Կ�������API ��ع��ܺ���ͼ��������ҳ����֧��
            services.AddControllersWithViews();
            //ֻ�Կ���������API��ʱ��
            //services.AddControllers();
            #endregion

            #region ע���Զ������

            //����ģʽע�����
            //ÿ������IClock�ӿڵ�ʱ�򣬷���ChinaClock��ʵ��
            services.AddSingleton<IClock, ChinaClock>();
            //HomeControllerʹ��IClock�ӿڽ��գ������
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
