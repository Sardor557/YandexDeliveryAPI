using System.Threading.Tasks;
using YandexDeliveryAPI.Services.Models.RequestModels;
using YandexDeliveryAPI.Services.Models.ResponseModels;
using YandexDeliveryAPI.Services.Models;

namespace YandexDeliveryAPI.Services.Interfaces
{
    public interface IDeliveryService
    {
        ValueTask<Answer<ClaimInfoModel>> CreateClaimAsync(ClaimModel model);
        ValueTask<Answer<ClaimInfoModel>> GetDeliveryStatusAsync(string uuid);
    }
}
