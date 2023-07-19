using Microsoft.Azure.Management.Sql.Fluent;

namespace Bazaar.Core.Api.Infrastructure.Provision.Services.Foundations.CloudManagements
{
    public class SqlDatabase
    {
        public ISqlDatabase Database { get; set; }
        public string ConnectionString { get; set; }
    }
}