using GV.Common.Models;

namespace GV.Common.Interfaces
{
    public interface IIpfsConnector
    {
        void WriteOrder(Manager manager, Order order);
    }
}
