using System.Threading.Tasks;
using YandexDeliveryAPI.Services.Models.RequestModels;
using YandexDeliveryAPI.Services.Models.ResponseModels;
using YandexDeliveryAPI.Services.Models;

namespace YandexDeliveryAPI.Services.Interfaces
{
    public interface IDeliveryService
    {
        ValueTask<Answer<CreatedClaimModel>> CreateClaimAsync(ClaimModel model);
        ValueTask<Answer<CreatedClaimModel>> GetDeliveryStatusAsync(string uuid);
    }
}
