using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;

namespace tagisApi.Lambda
{
    public class LambdaConfiguration : ILambdaConfiguration
    {
        public const string EnvKeyDbHost = "DATABASE_HOST";
        public const string EnvKeyDbName = "DATABASE_NAME";
        public const string EnvKeyDbUser = "DATABASE_USER";
        public const string EnvKeyDbPass = "DATABASE_PASS";
        
        public IConfiguration Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        public static string GetDatabaseCreds()
        {
            // Check if environment settings are set first (i.e. check if using Lambda)
            if (Environment.GetEnvironmentVariable(EnvKeyDbHost) != null)
            {
                string dbHost = Environment.GetEnvironmentVariable(EnvKeyDbHost);
                string dbName = Environment.GetEnvironmentVariable(EnvKeyDbName);
                string dbUser = Environment.GetEnvironmentVariable(EnvKeyDbUser);
                string dbPass = Environment.GetEnvironmentVariable(EnvKeyDbPass);

                return "server=" + dbHost + "; database=" + dbName + "; user id=" + dbUser + "; password=" + dbPass;
            }
            
            // If environment variables are not set, then use appsettings.json
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ILambdaConfiguration, LambdaConfiguration>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var configuration = serviceProvider.GetService<ILambdaConfiguration>();

            return configuration.Configuration["ConnectionStrings:Hosted"];
        }
    }
}