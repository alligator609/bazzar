using System.Threading.Tasks;
using Bazaar.Core.Api.Infrastructure.Provision.Services.Processings.CloudManagements;

namespace Bazaar.Core.Api.Infrastructure.Provision
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ICloudManagementProcessingService cloudManagementProcessingService =
               new CloudManagementProcessingService();

            await cloudManagementProcessingService.ProcessAsync();
        }
    }
}