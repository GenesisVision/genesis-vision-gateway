using GV.Common.Models;
using GV.Gateway.Common;

namespace GV.Common.Interfaces
{
    public interface IIpfsConnector
    {
        void WriteOrder(Manager manager, Order order);
    }
}
