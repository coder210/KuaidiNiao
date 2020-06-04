using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.KuaidiNiaoCore
{
    public class CancelOrderResult
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string EbusinessID { get; set; }

        /// <summary>
        /// 成功
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// 返回编码
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }
    }
}
