using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.KuaidiNiaoCore
{
    /// <summary>
    /// 快递鸟用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// user id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// api key
        /// </summary>
        public string APIKey { get; set; }

        public UserInfo()
        {
            this.ID = "1645757";
            this.APIKey = "c4e00fb1-8e41-4189-b7f4-a5f5a6ee806b";
        }
    }

}
