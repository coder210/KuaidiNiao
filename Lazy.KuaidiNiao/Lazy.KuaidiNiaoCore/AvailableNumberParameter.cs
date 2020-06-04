using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.KuaidiNiaoCore
{
    public class AvailableNumberParameter
    {
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 电子面单客户号
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 电子面单密码
        /// </summary>
        public string CustomerPwd { get; set; }

        /// <summary>
        /// 网点编码
        /// </summary>
        public string StationCode { get; set; }

        /// <summary>
        /// 网点名称
        /// </summary>
        public string StationName { get; set; }
    }
}
