using GV.Common.Interfaces;
using System;
using Xunit;
using NSubstitute;
using NLog;

namespace GV.Gateway.Tests
{
    public class GatewayServiceTests
    {
        private IEthAdapter ethAdapter;
        private ITradingPlatform tradingPlatform;
        private IGVExchanger exchanger;
        private GatewayService gateway;
        private ILogger logger;

        public GatewayServiceTests()
        {
            ethAdapter = Substitute.For<IEthAdapter>();
            tradingPlatform = Substitute.For<ITradingPlatform>();
            exchanger = Substitute.For<IGVExchanger>();
            logger = Substitute.For<ILogger>();
            gateway = new GatewayService(ethAdapter, tradingPlatform, exchanger, logger);
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
