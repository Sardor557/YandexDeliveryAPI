using System.Threading.Tasks;
using YandexDeliveryAPI.Services.Models.RequestModels;
using YandexDeliveryAPI.Services.Models.ResponseModels;
using YandexDeliveryAPI.Services.Models;
using Newtonsoft.Json.Linq;

namespace YandexDeliveryAPI.Services.Interfaces
{
    public interface IDeliveryService
    {
        ValueTask<Answer<ClaimInfoModel>> CreateClaimAsync(ClaimModel model);
        ValueTask<Answer<ClaimInfoModel>> GetDeliveryStatusAsync(string uuid);
        ValueTask<Answer<CancelClaimModel>> CancelClaimAsync(string uuid);
        ValueTask<Answer<CourierInfoModel>> GetCourierPhoneAsync(string uuid);
        ValueTask<Answer<ConfirmClaimModel>> ConfirmClaimAsync(string uuid);
    }
}
