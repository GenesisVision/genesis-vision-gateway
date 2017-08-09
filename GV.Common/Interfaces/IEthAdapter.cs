using GV.Common.Models;
using System;

namespace GV.Common.Interfaces
{
    public interface IEthAdapter
    {
        event Action<BindManagerRequest> BindManager;
    }
}
