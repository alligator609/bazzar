using Bazzar.Core.Api.Tests.Acceptance.Brokers;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Bazzar.Core.Api.Tests.Acceptance.APIs.Homes
{
    [Collection(nameof(ApiTestCollection))]
    public class HomeApiTests
    {
        private readonly BazzarApiBroker bazaarApiBroker;

        public HomeApiTests(BazzarApiBroker bazaarApiBroker) => this.bazaarApiBroker = bazaarApiBroker;

        [Fact]
        public async Task ShouldReturnHomeMessageAsync()
        {
            // given
            string expectedMessage =
                "Hello from Bazzar.Api! Look for bugs work on fixes";

            // when
            string actualMessage =
                await this.bazaarApiBroker.GetHomeMessageAsync();

            // then
            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}
