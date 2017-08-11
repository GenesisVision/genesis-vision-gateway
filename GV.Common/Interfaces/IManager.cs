using GV.Common.Models;
using System;

namespace GV.Common.Interfaces
{
    public interface IManager
    {
        event Action<Order> NewOrder;
    }
}
