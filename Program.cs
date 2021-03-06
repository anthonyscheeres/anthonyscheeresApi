using AnthonyscheeresApi.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace AnthonyscheeresApi
{
     internal class Program
    {


         public static void Main(string[] args)
        {
            ConfigFileInDocumetsFolderUtililities directoryUtilitiescs = new ConfigFileInDocumetsFolderUtililities(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/AnthonyScheeresServer/", "config.json");
            directoryUtilitiescs.writeDataModelToJsonFileInDocumetsFolder();
            CreateHostBuilder(args).Build().Run();
        }

         internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://0.0.0.0:8080/");
                   // webBuilder.UseKestrel();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                   // webBuilder.UseIISIntegration();
               
                    webBuilder.UseStartup<Startup>();
                });
    }
}
