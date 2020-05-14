using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                /*
                 * ���������Ϣ������µ������ļ�
                /*
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder.Sources.Clear();//������е�������Ϣ
                    configBuilder.AddJsonFile("nick.json");//����µ������ļ���ֻ��nick.json������
                })
                */
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
