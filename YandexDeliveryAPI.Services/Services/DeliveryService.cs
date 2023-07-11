using AsbtCore.UtilsV2;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
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
        private readonly HttpClient client;
        private readonly Settings settings;

        public DeliveryService(ILogger<DeliveryService> logger, IOptionsMonitor<Settings> settings)
        {
            this.logger = logger;
            this.settings = settings.CurrentValue;
            client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.settings.Y_TOKEN);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("ru"));
        }

        public async ValueTask<Answer<ClaimInfoModel>> CreateClaimAsync(ClaimModel model)
        {
            try
            {
                string reqUrl = string.Format(settings.CreateClaimUrl, model.Guid);
                model.Guid = null;
                var res = await RequestApiAsync<ClaimInfoModel>(new HttpRequestMessage(HttpMethod.Post, reqUrl), model);

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

        public async ValueTask<Answer<ClaimInfoModel>> GetDeliveryStatusAsync(string uuid)
        {
            try
            {
                string url = string.Format(settings.DeliveryStatusUrl, uuid);
                var res = await RequestApiAsync<ClaimInfoModel>(new HttpRequestMessage(HttpMethod.Post, url));

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

        public async ValueTask<Answer<CancelClaimModel>> CancelClaimAsync(string uuid)
        {
            try
            {
                string url = string.Format(settings.CancelClaimUrl, uuid);
                var cancel = new CancelModel { cancel_state = "free", version = 1 };
                var res = await RequestApiAsync<CancelClaimModel>(new HttpRequestMessage(HttpMethod.Post, url), cancel);

                return new Answer<CancelClaimModel>(0, "OK", "OK", res);
            }
            catch (Exception ex)
            {
                logger.LogError($"DeliveryService.CancelClaimAsync error :{ex.GetAllMessages()}");
                return new Answer<CancelClaimModel>(400, "Не опознанная ошибка", ex.Message);
            }
        }

        public async ValueTask<Answer<CourierInfoModel>> GetCourierPhoneAsync(string uuid)
        {
            try
            {
                var claim = new ClaimIdModel { claim_id = uuid };
                var res = await RequestApiAsync<CourierInfoModel>(new HttpRequestMessage(HttpMethod.Post, settings.CourierPhoneUrl), claim);
                return new Answer<CourierInfoModel>(0, "OK", "OK", res);
            }
            catch (Exception ex)
            {
                logger.LogError($"DeliveryService.GetCourierPhoneAsync error :{ex.GetAllMessages()}");
                return new Answer<CourierInfoModel>(400, "Не опознанная ошибка", ex.Message);
            }
        }

        public async ValueTask<Answer<ConfirmClaimModel>> ConfirmClaimAsync(string uuid)
        {
            try
            {
                string url = string.Format(settings.ConfirmClaimUrl, uuid);
                var version = new VersionModel { version = 1 };
                var res = await RequestApiAsync<ConfirmClaimModel>(new HttpRequestMessage(HttpMethod.Post, url), version);
                return new Answer<ConfirmClaimModel>(0, "OK", "OK", res);
            }
            catch (Exception ex)
            {
                logger.LogError($"DeliveryService.ConfirmClaimAsync error :{ex.GetAllMessages()}");
                return new Answer<ConfirmClaimModel>(400, "Не опознанная ошибка", ex.Message);
            }
        }

        public Answer<ClaimInfoModel> ListenCallbackAsync(object model)
        {
            try
            {
                var str = model.ToString();
                JObject.Parse(str);

                return new Answer<ClaimInfoModel>(0, "OK", "OK", null);
            }
            catch (Exception ex)
            {
                logger.LogError($"DeliveryService.ListenCallbackAsync error :{ex.GetAllMessages()}");
                return new Answer<ClaimInfoModel>(400, "Не опознанная ошибка", ex.Message);
            }
        }

        private async ValueTask<T> RequestApiAsync<T>(HttpRequestMessage req, object model = null)
        {
            try
            {
                if (model is not null)
                    req.Content = new StringContent(model.ToJson(), Encoding.UTF8, "application/json");

                var res = await client.SendAsync(req);
                var json = await res.Content.ReadAsStringAsync();
                return json.FromJson<T>();
            }
            finally { req.Dispose(); }
        }
    }
}
