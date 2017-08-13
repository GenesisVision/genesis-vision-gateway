using GV.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GV.Common.Models
{
    public class Manager
    {
        public string Name { get; set; }
        public decimal ManagementFee { get; set; }
        public decimal SuccessFee { get; set; }
        public string AccountCurrency { get; set; }
        public TradingPeriod TradingPeriod { get; set; }
        public DateTime NextClearing { get; set; }
    }
}
