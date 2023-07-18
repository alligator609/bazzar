using System;

namespace Bazaar.Core.Api.Infrastructure.Provision.Brokers.Loggings
{
    public class LoggingBroker
    {
        public void LogActivity(string message) => Console.WriteLine(message);
    }
}
