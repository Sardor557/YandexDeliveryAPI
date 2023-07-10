namespace YandexDeliveryAPI.Services.Models.ResponseModels
{
    public class ConfirmClaimModel
    {
        public string id { get; set; }
        public bool skip_client_notify { get; set; }
        public string status { get; set; }
        public string user_request_revision { get; set; }
        public int version { get; set; }

        public string code { get; set; }
        public string message { get; set; }
    }
}
