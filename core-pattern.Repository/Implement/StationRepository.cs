using core_pattern.Repository.ConditionModel;
using core_pattern.Repository.DataModel;
using core_pattern.Repository.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace core_pattern.Repository.Implement
{
    public class StationRepository : IStationRepository
    {
        public StationRepository()
        {
        }

        public async Task<IEnumerable<StationDataModel>> Station(StationConditionModel para)
        {
            HttpClient m_Http = new HttpClient();

            string url = $"https://ptx.transportdata.tw/MOTC/v2/Bike/Station/Taichung?$top=30&$format=JSON";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await m_Http.SendAsync(request);

            if (response.StatusCode != (HttpStatusCode)200)
            {
                throw new Exception("呼叫失敗");
            }

            var result = JObject.Parse(
               response.Content
                   .ReadAsStringAsync()
                   .ConfigureAwait(false)
                   .GetAwaiter()
                   .GetResult());
            List<StationDataModel> data = new List<StationDataModel>();
            data = result?.ToObject<List<StationDataModel>>();

            return data;
        }
    }
}