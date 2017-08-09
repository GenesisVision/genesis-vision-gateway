using GV.Gateway.Console.Models.Enums;
using System;

namespace GV.Gateway.Console.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string Symbol { get; set; }
        public decimal Volume { get; set; }
        public OrderDirection Direction { get; set; }
        public DateTime OpenTime { get; set; }
        public decimal OpenPrice { get; set; }
        public DateTime CloseTime { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal Profit { get; set; }
    }
}
