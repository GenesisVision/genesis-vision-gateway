using System;
using GV.Common.Models;
using GV.Common.Interfaces;

namespace GV.Gateway
{
    public class GatewayService
    {
        private IEthAdapter ethAdaptor;
        private ITradingPlatform tradingPlatform;

        public GatewayService(IEthAdapter ethAdaptor, ITradingPlatform tradingPlatform)
        {
            this.ethAdaptor = ethAdaptor;
            this.tradingPlatform = tradingPlatform;
        }

        public void Start()
        {
            ethAdaptor.BindManager += BindManager;
        }

        public void Stop()
        {

        }

        private void BindManager(BindManagerRequest manager)
        {
            tradingPlatform.BindManager(manager);
        }
    }
}
