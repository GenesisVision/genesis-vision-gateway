using GV.Common.Models;
using System.Collections.Generic;

namespace GV.Common.Interfaces
{
    public interface ITradingPlatform
    {
        /// <summary>
        /// Bind to trader in trading platform
        /// </summary>
        /// <returns></returns>
        bool BindManager(BindManagerRequest manager);

        /// <summary>
        /// Subscribe on managers orders and trades
        /// </summary>
        /// <param name="managers"></param>
        void SubscribeOnManagers(IEnumerable<string> managers);

        /// <summary>
        /// Manager was deactivated in Genesis Vision
        /// </summary>
        /// <param name=""></param>
        void DeactivateManager(string manager);
    }
}
