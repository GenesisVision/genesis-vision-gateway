using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GV.Gateway.Console.Models
{
    public class NewInvestment
    {
        public string Investor { get; set; }
        public string Manager { get; set; }
        public BigInteger GvtCount {get;set;}
    }
}
