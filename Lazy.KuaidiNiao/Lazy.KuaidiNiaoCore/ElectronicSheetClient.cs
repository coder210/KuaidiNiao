using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lazy.KuaidiNiaoCore
{
    /// <summary>
    /// 电子面单
    /// </summary>
    public class ElectronicSheetClient
    {
        public string Url { get; }
        public UserInfo UserInfo { get; }
        public ElectronicSheetClient(UserInfo userInfo)
        {
            this.UserInfo = userInfo;

            // 正式环境: http://api.kdniao.com/api/EOrderService
            // 测试环境: http://testapi.kdniao.com:8081/api/EOrderService
            //this.Url = "http://testapi.kdniao.com:8081/api/EOrderService";
            this.Url = "http://api.kdniao.com/api/EOrderService";
        }

        /// <summary>
        /// 获取可用单量
        /// 仅只支持优速,中通,韵达,百世
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public string GetAvailableNumber(AvailableNumberParameter parameter)
        {
            string requestData = Utils.Serialize(parameter);
            RestClient client = new RestClient(this.Url);
            IRestRequest request = new RestRequest();
            request.AddParameter("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            request.AddParameter("EBusinessID", UserInfo.ID);
            request.AddParameter("RequestType", "3001");
            string dataSign = Utils.Sign(requestData, UserInfo.APIKey, "UTF-8");
            request.AddParameter("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            request.AddParameter("DataType", "2");
            var response = client.Post(request);
            return response.Content;
        }
        public AvailableNumberResult GetAvailableNumberAndAnalysis(AvailableNumberParameter parameter)
        {
            var result = this.GetAvailableNumber(parameter);
            return Utils.Deserialize<AvailableNumberResult>(result);
        }

        /// <summary>
        /// 提交订单,在快递鸟官网上会有一条订单记录
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string SubmitOrder(SubmitOrderParameter parameter)
        {
            string requestData = Utils.Serialize(parameter);
            RestClient client = new RestClient(this.Url);
            IRestRequest request = new RestRequest();
            request.AddParameter("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            request.AddParameter("EBusinessID", UserInfo.ID);
            request.AddParameter("RequestType", "1007");
            string dataSign = Utils.Sign(requestData, UserInfo.APIKey, "UTF-8");
            request.AddParameter("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            request.AddParameter("DataType", "2");
            var response = client.Post(request);
            return response.Content;
        }

        public SubmitOrderResult SubmitOrderAndAnalysis(SubmitOrderParameter parameter)
        {
            string result = this.SubmitOrder(parameter);
            return Utils.Deserialize<SubmitOrderResult>(result);
        }

        /// <summary>
        /// 取消订单,但其快递鸟的物流信息记录还会存在
        /// 只是表明这个单号不能用了
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string CancelOrder(CancelOrderParameter parameter)
        {
            RestClient client = new RestClient(this.Url);
            IRestRequest request = new RestRequest();
            string requestData = Utils.Serialize(parameter);
            request.AddParameter("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            request.AddParameter("EBusinessID", UserInfo.ID);
            request.AddParameter("RequestType", "1147");
            string dataSign = Utils.Sign(requestData, UserInfo.APIKey, "UTF-8");
            request.AddParameter("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            request.AddParameter("DataType", "2");
            var response = client.Post(request);
            return response.Content;
        }

        public CancelOrderResult CancelOrderAndAnalysis(CancelOrderParameter parameter)
        {
            var result = this.CancelOrder(parameter);
            return Utils.Deserialize<CancelOrderResult>(result);
        }

        /// <summary>
        /// 获得打印参数
        /// </summary>
        /// <param name="parameterList">参数列表</param>
        /// <returns></returns>
        public PrintOrderPackageResult GetPrintOrderPackage(List<PrintOrderParameter> parameterList)
        {
            string requestData = HttpUtility.UrlEncode(Utils.Serialize(parameterList), Encoding.UTF8);
            string dataSign = Utils.Sign(Utils.GetIp() + requestData, UserInfo.APIKey, "UTF-8");
            PrintOrderPackageResult result = new PrintOrderPackageResult()
            {
                RequestData = HttpUtility.UrlEncode(requestData, Encoding.UTF8),
                DataSign = HttpUtility.UrlEncode(dataSign, Encoding.UTF8),
                EBusinessID = UserInfo.ID,
                IsPreview = 1
            };
            return result;
        }


    }
}
