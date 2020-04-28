using core_pattern.Common.Security;
using core_pattern.Repository.ConditionModel;
using core_pattern.Repository.DataModel;
using core_pattern.Repository.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace core_pattern.Repository.Implement
{
    public class StationRepository : IStationRepository
    {
        private readonly HttpClient _httpClient;

        public StationRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<StationDataModel>> Station(StationConditionModel para)
        {
            NameValueCollection parameter = HttpUtility.ParseQueryString(String.Empty);

            parameter.Add($"$top", para.top.ToString());

            if (!string.IsNullOrWhiteSpace(para.filter))
            {
                parameter.Add($"$filter", para.filter);
            }

            if (!string.IsNullOrWhiteSpace(para.select))
            {
                parameter.Add($"$select", para.select);
            }

            string url = $@"https://ptx.transportdata.tw/MOTC/v2/Bike/Station/{para.City}";

            url = $"{url}?{parameter.ToString().Replace("+", "")}";
            //申請的APPID
            //（FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF 為 Guest 帳號，以IP作為API呼叫限制，請替換為註冊的APPID & APPKey）
            string APPID = "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF";
            //申請的APPKey
            string APPKey = "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF";

            //取得當下UTC時間
            string xdate = DateTime.Now.ToUniversalTime().ToString("r");
            string SignDate = "x-date: " + xdate;
            //取得加密簽章
            string Signature = HMAC_SHA1.Signature(SignDate, APPKey);
            string sAuth = "hmac username=\"" + APPID + "\", algorithm=\"hmac-sha1\", headers=\"x-date\", signature=\"" + Signature + "\"";

            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };

            string Result = string.Empty;

            using (HttpClient Client = new HttpClient(handler))
            {
                Client.DefaultRequestHeaders.Add("Authorization", sAuth);
                Client.DefaultRequestHeaders.Add("x-date", xdate);
                Result = Client.GetStringAsync(url).Result;
            }

            List<StationDataModel> data = new List<StationDataModel>();
            data = JsonConvert.DeserializeObject<List<StationDataModel>>(Result);

            return data;
        }
    }
}