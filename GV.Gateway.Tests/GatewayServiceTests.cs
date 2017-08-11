using GV.Common.Interfaces;
using System;
using Xunit;
using Moq;

namespace GV.Gateway.Tests
{
    public class GatewayServiceTests
    {
        private Mock<IEthAdapter> ethAdapter;
        private Mock<ITradingPlatform> tradingPlatform;
        private GatewayService gateway;

        public GatewayServiceTests()
        {
            ethAdapter = new Mock<IEthAdapter>();
            tradingPlatform = new Mock<ITradingPlatform>();
            gateway = new GatewayService(ethAdapter.Object, tradingPlatform.Object);
            gateway.Start();
        }

        [Fact]
        public void DeactivateManager()
        {
            tradingPlatform.Setup(t => t.DeactivateManager("test"));
            ethAdapter.Raise(e => e.DeactivateManager += null, "test");

            tradingPlatform.VerifyAll();
        }
    }
}
