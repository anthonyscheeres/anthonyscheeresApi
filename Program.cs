using AnthonyscheeresApi.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace AnthonyscheeresApi
{
    public class Program
    {


        public static void Main(string[] args)
        {
            ConfigFileInDocumetsFolderUtililities directoryUtilitiescs = new ConfigFileInDocumetsFolderUtililities("config.json");
            directoryUtilitiescs.writeDataModelToJsonFileInDocumetsFolder();



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://0.0.0.0:8080/");
                    webBuilder.UseKestrel();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseIISIntegration();
               
                    webBuilder.UseStartup<Startup>();
                });
    }
}
