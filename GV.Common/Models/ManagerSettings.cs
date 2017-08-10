using GV.Common.Models.Enums;

namespace GV.Common.Models
{
    public class ManagerSettings
    {
        public decimal ManagementFee { get; set; }
        public decimal SuccessFee { get; set; }
        public TradingPeriod TradingPeriod { get; set; }
    }
}
