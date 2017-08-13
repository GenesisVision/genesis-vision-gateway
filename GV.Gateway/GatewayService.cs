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
        private IGVExchanger exchanger;

        public GatewayService(
            IEthAdapter ethAdapter,
            ITradingPlatform tradingPlatform,
            IGVExchanger exchanger,
            ILogger logger)
        {
            this.logger = logger;
            this.ethAdapter = ethAdapter;
            this.exchanger = exchanger;
            this.tradingPlatform = tradingPlatform;
        }


        public void Start()
        {
            logger.Info("Genesis Vision Gateway starting...");
            var managers = ethAdapter.GetManagers();
            tradingPlatform.SubscribeOnManagers(managers.Select(m => m.Name).ToList());

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
            var managers = ethAdapter.GetManagers();
            var now = ethAdapter.Now;
            foreach (var manager in managers.Where(m => m.NextClearing <= now))
            {
                ManagerClearing(manager);
            }
        }

        private void ManagerClearing(Manager manager)
        {
            var clearingData = ethAdapter.GetClearingData(manager.Name);
            ethAdapter.MakeClearing(manager.Name); // TODO async

            var changeDeposit = clearingData.InputGVT - clearingData.OutputGVT; // Todo manager share
            if(changeDeposit == 0)
                return;

            decimal changeBalance = 0;
            if(changeDeposit > 0)
            {
                changeBalance = exchanger.Exchange("GVT", manager.AccountCurrency);
                tradingPlatform.ChangeBalance(manager.Name, changeBalance);
            }
            else
            {
                changeBalance = exchanger.Exchange(manager.AccountCurrency, "GVT");
                tradingPlatform.ChangeBalance(manager.Name, -changeBalance);
            }
        }
    }
}
