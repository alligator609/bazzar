using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Core.Api.Tests.Acceptance.Brokers
{
        public partial class BazzarApiBroker
    {
            private const string HomeRelativeUrl = "api/home";

            public async ValueTask<string> GetHomeMessageAsync() =>
                await this.apiFactoryClient.GetContentStringAsync(HomeRelativeUrl);
        }
}
