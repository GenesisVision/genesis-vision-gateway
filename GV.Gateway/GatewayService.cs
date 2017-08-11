using GV.Common.Models;
using GV.Common.Interfaces;
using System.Linq;

namespace GV.Gateway
{
    public class GatewayService
    {
        private IEthAdapter ethAdapter;
        private ITradingPlatform tradingPlatform;

        public GatewayService(IEthAdapter ethAdapter, ITradingPlatform tradingPlatform)
        {
            this.ethAdapter = ethAdapter;
            this.tradingPlatform = tradingPlatform;
        }

        public void Start()
        {
            var managers = ethAdapter.GetManagers();
            tradingPlatform.SubscribeOnManagers(managers);

            ethAdapter.BindManager += BindManager;
            ethAdapter.DeactivateManager += DeactivateManager;
        }

        
        public void Stop()
        {
            ethAdapter.DeactivateManager -= DeactivateManager;
            ethAdapter.BindManager -= BindManager;
        }

        private void DeactivateManager(string manager)
        {
            tradingPlatform.DeactivateManager(manager);
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
