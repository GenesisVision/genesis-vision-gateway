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

        IEnumerable<Manager> GetManagers();

        ClearingData GetClearingData(string manager);
        void MakeClearing(string manager);
    }
}
