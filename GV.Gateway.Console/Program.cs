namespace GV.Gateway.Console
{
    using System;
    using NSubstitute;
    using GV.Common.Interfaces;
    using NLog;
    using NLog.Targets;
    using NLog.Config;

    class Program
    {
        private static Logger logger;

        static void Main(string[] args)
        {
            ConfigureLog();

            var ethAdapter = Substitute.For<IEthAdapter>();
            var tradingPlatform = Substitute.For<ITradingPlatform>();
            var exchanger = Substitute.For<IGVExchanger>();

            var gateway = new GatewayService(ethAdapter, tradingPlatform, exchanger, logger);
            gateway.Start();

            Console.ReadLine();
        }

        private static void ConfigureLog()
        {
            var config = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);
            LogManager.Configuration = config;
            logger = LogManager.GetLogger("GenesisVision Console");
        }
    }
}