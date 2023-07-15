using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.Core.Api.Infrastructure.Provision.Brokers.Clouds
{
	public partial class CloudBroker
    {
		public partial interface ICloudBroker
		{
			ValueTask<bool> CheckResourceGroupExistsAsync(string resourceGroupName);
			ValueTask<IResourceGroup> CreateResourceGroupAsync(string resourceGroupName);
			ValueTask DeleteResourceGroupAsync(string resourceGroupName);
		}
	}
}
