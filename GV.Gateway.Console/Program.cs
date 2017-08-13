namespace GV.Gateway.Console
{
    using System;
    using NSubstitute;
    using GV.Common.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            var ethAdapter = Substitute.For<IEthAdapter>();
            var tradingPlatform = Substitute.For<ITradingPlatform>();

            var gateway = new GatewayService(ethAdapter, tradingPlatform);

            Console.ReadLine();
        }
    }
}