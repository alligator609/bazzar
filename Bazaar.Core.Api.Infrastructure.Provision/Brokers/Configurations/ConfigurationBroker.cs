using System.IO;
using Bazaar.Core.Api.Infrastructure.Provision.Models.Configurations;
using Microsoft.Extensions.Configuration;

namespace Bazaar.Core.Api.Infrastructure.Provision.Brokers.Configurations
{
    public class ConfigurationBroker : IConfigurationBroker
    {
        public CloudManagementConfiguration GetConfiguration()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
             .SetBasePath(basePath: Directory.GetCurrentDirectory())
             .AddJsonFile(path: "appSettings.json", optional: false)
             .Build();

            return configurationRoot.Get<CloudManagementConfiguration>();
        }
    }
}
