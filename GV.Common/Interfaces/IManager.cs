using System;

namespace GV.Gateway.Common.Interfaces
{
    public interface IManager
    {
        event Action<Order> NewOrder;
    }
}
