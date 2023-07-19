﻿using System;

namespace Bazaar.Core.Api.Infrastructure.Provision.Brokers.Loggings
{
    public class LoggingBroker :ILoggingBroker
    {
        public void LogActivity(string message) => Console.WriteLine(message);
    }
}
