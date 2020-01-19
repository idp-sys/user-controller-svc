using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace UserManager.Shared
{
    public  class LoggerFactoryBuilder
    {
       public ILoggerFactory ConfigureLogger()
        {
            LoggerFactory factory = new LoggerFactory();
           
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile(path: "logging.json", optional: false, reloadOnChange: true)
             .Build();

            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(path:"log.txt")
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
           
            factory.AddSerilog(logger);

            return factory;
        }

    }
}
