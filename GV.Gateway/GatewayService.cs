using GV.Common.Models;
using GV.Common.Interfaces;
using System.Linq;
using System.Threading;
using System;

namespace GV.Gateway
{
    public class GatewayService
    {
        private readonly int TimerPeriod = 60 * 1000;
        private IEthAdapter ethAdapter;
        private ITradingPlatform tradingPlatform;

        private Timer timer;

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

            timer = new Timer(OnTimer, null, TimerPeriod, TimerPeriod);
        }


        public void Stop()
        {
            timer.Dispose();
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

        private void OnTimer(object state)
        {
            Console.WriteLine("Test");
        }
    }
}
