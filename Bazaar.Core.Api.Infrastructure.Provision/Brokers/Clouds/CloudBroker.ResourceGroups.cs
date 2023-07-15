using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.Core.Api.Infrastructure.Provision.Brokers.Clouds
{
    public partial class CloudBroker
    {
        public async ValueTask<bool> CheckResourceGroupExistsAsync(string resourceGroupName) =>
            await azure.ResourceGroups.ContainAsync(resourceGroupName);

        public async ValueTask<IResourceGroup> CreateResourceGroupAsync(
            string resourceGroupName)
        {
            return await this.azure.ResourceGroups
                .Define(resourceGroupName)
                .WithRegion(Region.IndiaCentral)
                .CreateAsync();
        }

        public async ValueTask DeleteResourceGroupAsync(string resourceGroupName) =>
            await this.azure.ResourceGroups.DeleteByNameAsync(resourceGroupName);
    }
}
