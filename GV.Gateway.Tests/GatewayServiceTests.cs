using GV.Common.Interfaces;
using System;
using Xunit;
using NSubstitute;

namespace GV.Gateway.Tests
{
    public class GatewayServiceTests
    {
        private IEthAdapter ethAdapter;
        private ITradingPlatform tradingPlatform;
        private GatewayService gateway;

        public GatewayServiceTests()
        {
            ethAdapter = Substitute.For<IEthAdapter>();
            tradingPlatform = Substitute.For<ITradingPlatform>();
            gateway = new GatewayService(ethAdapter, tradingPlatform);
            gateway.Start();
        }

        [Fact]
        public void DeactivateManager()
        {
            tradingPlatform.DeactivateManager("test");
            ethAdapter.DeactivateManager += Raise.Event<Action<string>>("test");

            tradingPlatform.Received().DeactivateManager("test");
        }
    }
}
