using AsbtCore.UtilsV2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YandexDeliveryAPI.Services.Interfaces;
using YandexDeliveryAPI.Services.Models;
using YandexDeliveryAPI.Services.Models.RequestModels;
using YandexDeliveryAPI.Services.Models.ResponseModels;

namespace YandexDeliveryAPI.Services.Services
{
    public sealed class DeliveryService : IDeliveryService
    {
        private readonly ILogger<DeliveryService> logger;
        private readonly IConfiguration conf;
        private readonly HttpClient client;

        public DeliveryService(ILogger<DeliveryService> logger, IConfiguration conf)
        {
            this.logger = logger;
            this.conf = conf;
            client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", conf["YandexAPI:Y_TOKEN"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("ru"));
        }

        public async ValueTask<Answer<ClaimInfoModel>> CreateClaimAsync(ClaimModel model)
        {
            try
            {
                string reqUrl = string.Format(conf["YandexAPI:CreateClaim"], model.Guid);
                model.Guid = null;
                var res = await RequestApiAsync(new HttpRequestMessage(HttpMethod.Post, reqUrl), model);

                if (!res.code.IsNullorEmpty() && res.code != "200")
                    return new Answer<ClaimInfoModel>(600, $"Ошибка при запросе, код: {res.code}", res.message);

                return new Answer<ClaimInfoModel>(0, "OK", "OK", res);
            }
            catch (Exception ex)
            {
                logger.LogError($"DeliveryService.CreateClaimAsync error :{ex.GetAllMessages()}");
                return new Answer<ClaimInfoModel>(400, "Не опознанная ошибка", ex.Message);
            }
        }

        private async ValueTask<ClaimInfoModel> RequestApiAsync(HttpRequestMessage req, ClaimModel model = null)
        {
            try
            {    
                if (model is not null)
                    req.Content = new StringContent(model.ToJson(), Encoding.UTF8, "application/json");

                var res = await client.SendAsync(req);
                var json = await res.Content.ReadAsStringAsync();
                return json.FromJson<ClaimInfoModel>();
            }
            finally { req.Dispose(); }
        }

        public async ValueTask<Answer<ClaimInfoModel>> GetDeliveryStatusAsync(string uuid)
        {
            try
            {
                string url = string.Format(conf["YandexAPI:GetDeliveryStatus"], uuid);
                var res = await RequestApiAsync(new HttpRequestMessage(HttpMethod.Post, url));

                if (!res.code.IsNullorEmpty() && res.code != "200")                
                    return new Answer<ClaimInfoModel>(600, $"Ошибка при запросе, код: {res.code}", res.message);
                
                return new Answer<ClaimInfoModel>(0, "OK", "OK", res);
            }
            catch (Exception ex)
            {
                logger.LogError($"DeliveryService.GetDeliveryStatusAsync error :{ex.GetAllMessages()}");
                return new Answer<ClaimInfoModel>(400, "Не опознанная ошибка", ex.Message);
            }
        }
    }
}
