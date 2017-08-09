using GV.Common.Models;

namespace GV.Common.Interfaces
{
    public interface ITradingPlatform
    {
        bool BindManager(BindManagerRequest manager);
    }
}
