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

        /// <summary>
        /// �м��ע���˳�����Ҫ��ע���˳�����http������˳��
        /// IApplicationBuilder��Program.cs�е�CreateDefaultBuilder��������ע��
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
             * ͨ������ ASPNETCORE_ENVIRONMENT �ж��Ƿ�Ϊ����������������������
             * IsEnvironment(����ֵ)�����ж��Զ���ı���ֵ
             */
            if (env.IsDevelopment())
            {
                //һ���쳣ҳ�м���������������쳣��ʱ��ת��һ����ʾ������Ϣ��ҳ��
                app.UseDeveloperExceptionPage();
            }

            //�ġ���̬��Դ�м����css��js��html��ֻ��ʮһ���м�������ܷ��ʾ�̬�ļ�
            app.UseStaticFiles();

            //app.UseHttpsRedirection();//��http����ת��Ϊhttps����
            //app.UseAuthentication();//��֤�м���������ڶ˵��м��ǰ��
            
            /*
             * ����·���м��������Ѿ�ע��Ķ˵�
             * �˵㣺������http�����url��β���ǲ��֣��ⲿ�ֻᱻ�м�����д���
             */
            app.UseRouting();

            /*
             * �����˵��м��
             */
            app.UseEndpoints(endpoints =>
            {
                //1.��ʾ�˵�Ϊ/��ʱ�򣬷���
                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/

                //2.MVC��·�ɱ�ģ��
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                //3.MVC��controller��action��ʹ��ע���ע��·��ģ��
                //endpoints.MapControllers();
            });
        }
    }
}
