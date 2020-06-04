using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.KuaidiNiaoCore
{
    public class AvailableNumberResult
    {
        public string EbusinessID { get; set; }
        public bool Success { get; set; }
        public string Reason { get; set; }
        public string ReasonCode { get; set; }
        public EorderBalanceInfo EorderBalance { get; set; }

        public class EorderBalanceInfo
        {
            public int AvailableNum { get; set; }
            public int TotalNum { get; set; }
        }
    }
}
