using GV.Common.Models;
using System;
using System.Collections.Generic;

namespace GV.Common.Interfaces
{
    public interface IEthAdapter
    {
        event Action<BindManagerRequest> BindManager;
        event Action<string> DeactivateManager;

        DateTime Now { get; }

        IEnumerable<string> GetManagers();
    }
}
