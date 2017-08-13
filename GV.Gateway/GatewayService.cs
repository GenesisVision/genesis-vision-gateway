using GV.Common.Models;
using GV.Common.Interfaces;
using System.Linq;
using System.Threading;
using System;
using NLog;

namespace GV.Gateway
{
    public class GatewayService
    {
        private readonly int TimerPeriod = 60 * 1000;
        private IEthAdapter ethAdapter;
        private ITradingPlatform tradingPlatform;

        private Timer timer;
        private ILogger logger;

        public GatewayService(IEthAdapter ethAdapter, ITradingPlatform tradingPlatform, 
            NLog.ILogger logger)
        {
            this.logger = logger;
            this.ethAdapter = ethAdapter;
            this.tradingPlatform = tradingPlatform;
        }


        public void Start()
        {
            logger.Info("Genesis Vision Gateway starting...");
            var managers = ethAdapter.GetManagers();
            tradingPlatform.SubscribeOnManagers(managers);

            ethAdapter.BindManager += BindManager;
            ethAdapter.DeactivateManager += DeactivateManager;

            timer = new Timer(OnTimer, null, TimerPeriod, TimerPeriod);
            logger.Info("Genesis Vision Gateway started");
        }


        public void Stop()
        {
            logger.Info("Genesis Vision Gateway stopping...");

            timer.Dispose();
            ethAdapter.DeactivateManager -= DeactivateManager;
            ethAdapter.BindManager -= BindManager;
            logger.Info("Genesis Vision Gateway stopped");
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
            logger.Debug("Gateway scheduler on timer");
        }
    }
}
