using System.Collections.Generic;
using System.Threading.Tasks;
using Bazaar.Core.Api.Infrastructure.Provision.Brokers.Configurations;
using Bazaar.Core.Api.Infrastructure.Provision.Models.Configurations;
using Bazaar.Core.Api.Infrastructure.Provision.Models.Storages;
using Bazaar.Core.Api.Infrastructure.Provision.Services.Foundations.CloudManagements;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;

namespace Bazaar.Core.Api.Infrastructure.Provision.Services.Processings.CloudManagements
{
    public class CloudManagementProcessingService : ICloudManagementProcessingService
    {
        private readonly ICloudManagementService cloudManagementService;
        private readonly IConfigurationBroker configurationBroker;
        public CloudManagementProcessingService()
        {
            this.cloudManagementService = new CloudManagementService();
            this.configurationBroker = new ConfigurationBroker();
        }

        public async ValueTask ProcessAsync()
        {
            CloudManagementConfiguration cloudManagementConfiguration =
                 this.configurationBroker.GetConfiguration();

            await ProvisionAsync(
                projectName: cloudManagementConfiguration.ProjectName,
                cloudAction: cloudManagementConfiguration.Up);
        }
        private async ValueTask ProvisionAsync(
           string projectName,
           CloudAction cloudAction)
        {
            List<string> environments = RetrieveEnvironments(cloudAction);

            foreach (string environmentName in environments)
            {
                IResourceGroup resourceGroup = await this.cloudManagementService
                    .ProvisionResourceGroupAsync(
                        projectName,
                        environmentName);

                IAppServicePlan appServicePlan = await this.cloudManagementService
                    .ProvisionAppServicePlanAsync(
                        projectName,
                        environmentName,
                        resourceGroup);

                ISqlServer sqlServer = await this.cloudManagementService
                    .ProvisionSqlServerAsync(
                        projectName,
                        environmentName,
                        resourceGroup);

                SqlDatabase sqlDatabase = await this.cloudManagementService
                    .ProvisionSqlDatabaseAsync(
                        projectName,
                        environmentName,
                        sqlServer);

                IWebApp webApp = await this.cloudManagementService
                    .ProvisionWebAppAsync(
                        projectName,
                        environmentName,
                        sqlDatabase.ConnectionString,
                        appServicePlan,
                        resourceGroup
                        );
            }
        }
        private static List<string> RetrieveEnvironments(CloudAction cloudAction) =>
            cloudAction?.Environments ?? new List<string>();
    }
}
