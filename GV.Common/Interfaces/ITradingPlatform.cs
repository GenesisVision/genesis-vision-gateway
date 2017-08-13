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
        void SubscribeOnManagers(IEnumerable<string> managers);

        /// <summary>
        /// Manager was deactivated in Genesis Vision
        /// </summary>
        void DeactivateManager(string manager);

        /// <summary>
        /// Change account deposit
        /// </summary>
        void ChangeBalance(string manager, decimal changeBalanceValue);
    }
}
