using GV.Common.Models;
using GV.Common.Interfaces;
using System.Linq;

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
            var managers = ethAdaptor.GetManagers();
            tradingPlatform.SubscribeOnManagers(managers);

            ethAdaptor.BindManager += BindManager;
        }

        public void Stop()
        {
            ethAdaptor.BindManager -= BindManager;
        }

        private void BindManager(BindManagerRequest manager)
        {
            if (tradingPlatform.BindManager(manager))
            {
                tradingPlatform.SubscribeOnManagers(Enumerable.Repeat(manager.Login, 1));
            }
            else
            {
                // TODO handle error
            }
        }
    }
}
