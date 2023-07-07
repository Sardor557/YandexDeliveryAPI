using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using YandexDeliveryAPI.Services.Interfaces;
using YandexDeliveryAPI.Services.Models;
using YandexDeliveryAPI.Services.Models.RequestModels;
using YandexDeliveryAPI.Services.Models.ResponseModels;

namespace YandexDeliveryAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [SwaggerTag("Доставка")]
    //[Authorize]

    public class DeliveryController
    {
        private readonly IDeliveryService service;

        public DeliveryController(IDeliveryService service) => this.service = service;

        [HttpPost("create_claim")]
        public ValueTask<Answer<CreatedClaimModel>> CreateClaimAsync(ClaimModel claim) => service.CreateClaimAsync(claim);

        [HttpGet("{uuid}")]
        public ValueTask<Answer<CreatedClaimModel>> GetDeliveryStatusAsync(string uuid) => service.GetDeliveryStatusAsync(uuid);
    }
}
