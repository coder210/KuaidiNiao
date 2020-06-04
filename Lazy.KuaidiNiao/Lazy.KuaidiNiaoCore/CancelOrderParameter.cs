using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.KuaidiNiaoCore
{
    public class CancelOrderParameter
    {
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        public string ExpNo { get; set; }

        /// <summary>
        /// 电子面单客户号
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 电子面单密码
        /// 顺风不需要
        /// </summary>
        public string CustomerPwd { get; set; }
    }
}
