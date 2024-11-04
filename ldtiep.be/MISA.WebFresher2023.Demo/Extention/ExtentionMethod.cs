
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ldtiep.be.Common
{
    public static class ExtensionMethod
    {
        public static void ReadConfig(this WebApplicationBuilder builder)
        {
            //string baseUrl = AppDomain.CurrentDomain.BaseDirectory;

            //string projectName = Assembly.GetExecutingAssembly().GetName().Name ?? "ldtiep.be";

            //int index = baseUrl.LastIndexOf(projectName);

            //if (index != -1)
            //{
                //string path = baseUrl[..index] + @"default.json";
            //string path = "D:\\do-an\\ldtiep.be\\default.json";

            //builder.Configuration.AddJsonFile(path);
            //}
            //else
            //{
            //    throw new InternalException();
            //}

        }
        public static AppConfig GetConfig(this IConfiguration configuration)
        {
            AppConfig config = new();

            new ConfigureFromConfigurationOptions<AppConfig>(configuration).Configure(config);

            return config;
        }

    }
}
