using GV.Gateway.Common.Interfaces;
using System;

namespace GV.Gateway.EthMediator
{
    public interface IEthMediator
    {
        event Action<IManager> NewManager;
    }
}
