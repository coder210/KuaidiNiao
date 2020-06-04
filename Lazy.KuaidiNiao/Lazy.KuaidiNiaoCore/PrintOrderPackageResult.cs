using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.KuaidiNiaoCore
{
    public class PrintOrderPackageResult
    {
        public string RequestData { get; set; }
        public string EBusinessID { get; set; }
        public string DataSign { get; set; }

        /// <summary>
        /// 0:不预览,
        /// 1:预览
        /// </summary>
        public int IsPreview { get; set; }
    }
}
