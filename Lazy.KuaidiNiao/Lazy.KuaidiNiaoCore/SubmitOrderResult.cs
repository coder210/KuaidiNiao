using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.KuaidiNiaoCore
{
    /// <summary>
    /// 电子面单返回值
    /// </summary>
    public class SubmitOrderResult
    {
        public string EBusinessID { get; set; }
        public bool Success { get; set; }
        public string UniquerRequestNumber { get; set; }
        public OrderInfo Order { get; set; }
        public string Reason { get; set; }
        public string ResultCode { get; set; }
        public string PrintTemplate { get; set; }

        /// <summary>
        /// 订单信息
        /// </summary>
        public class OrderInfo
        {
            /// <summary>
            /// 商户订单号
            /// </summary>
            public string OrderCode { get; set; }
            /// <summary>
            /// 快递单号
            /// </summary>
            public string LogisticCode { get; set; }
            /// <summary>
            /// 始发地区编码
            /// </summary>
            public string OriginCode { get; set; }
            /// <summary>
            /// 目的地区编码
            /// </summary>
            public string DestinatioCode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string KDNOrderCode { get; set; }
        }
    }
}
