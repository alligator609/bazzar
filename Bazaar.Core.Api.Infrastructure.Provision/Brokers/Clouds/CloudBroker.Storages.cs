﻿using Bazaar.Core.Api.Infrastructure.Provision.Models.Storages;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using System.Threading.Tasks;

namespace Bazaar.Core.Api.Infrastructure.Provision.Brokers.Clouds
{
    public partial class CloudBroker
    {
        public async ValueTask<ISqlServer> CreateSqlServerAsync(
           string sqlServerName,
           IResourceGroup resourceGroup)
        {
            return await this.azure.SqlServers
                .Define(sqlServerName)
                .WithRegion(Region.IndiaCentral)
                .WithExistingResourceGroup(resourceGroup)
                .WithAdministratorLogin(this.adminName)
                .WithAdministratorPassword(this.adminAccess)
                .CreateAsync();
        }
        public async ValueTask<ISqlDatabase> CreateSqlDatabaseAsync(
            string sqlDatabaseName,
            ISqlServer sqlServerName)
        {
            return await this.azure.SqlServers
                 .Databases
                 .Define(sqlDatabaseName)
                 .WithExistingSqlServer(sqlServerName)
                 .CreateAsync();
        }
        public SqlDatabaseAccess GetSqlDatabaseAccess()
        {
            return new SqlDatabaseAccess
            {
                AdminName = this.adminName,
                AdminAccess = this.adminAccess
            };
        }
    }


}
