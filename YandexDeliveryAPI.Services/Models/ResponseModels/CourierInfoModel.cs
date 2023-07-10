namespace YandexDeliveryAPI.Services.Models.ResponseModels
{
    public class CourierInfoModel
    {
        public string phone { get; set; }
        public string ext { get; set; }
        public int ttl_seconds { get; set; }

        public string code { get; set; }
        public string message { get; set; }
    }

}
