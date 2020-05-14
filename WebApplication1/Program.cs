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
                 * 清除配置信息，添加新的配置文件
                /*
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder.Sources.Clear();//清除所有的配置信息
                    configBuilder.AddJsonFile("nick.json");//添加新的配置文件，只有nick.json起作用
                })
                */
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
