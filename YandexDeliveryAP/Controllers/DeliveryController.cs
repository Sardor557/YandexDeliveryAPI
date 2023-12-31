﻿using Microsoft.AspNetCore.Authorization;
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
        public ValueTask<Answer<ClaimInfoModel>> CreateClaimAsync([FromBody] ClaimModel claim) => service.CreateClaimAsync(claim);

        [HttpGet("status/{uuid}")]
        public ValueTask<Answer<ClaimInfoModel>> GetDeliveryStatusAsync(string uuid) => service.GetDeliveryStatusAsync(uuid);

        [HttpGet("cancel/{uuid}")]
        public ValueTask<Answer<CancelClaimModel>> CancelClaimAsync(string uuid) => service.CancelClaimAsync(uuid);

        [HttpGet("courier_info/{uuid}")]
        public ValueTask<Answer<CourierInfoModel>> GetCourierInfoAsync(string uuid) => service.GetCourierInfoAsync(uuid);

        [HttpGet("confirm/{uuid}")]
        public ValueTask<Answer<ConfirmClaimModel>> ConfirmClaimAsync(string uuid) => service.ConfirmClaimAsync(uuid);
    }
}
