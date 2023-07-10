namespace YandexDeliveryAPI.Services.Models.RequestModels
{
    public sealed class CancelClaimModel
    {
        public int? version { get; set; }
        public string cancel_state { get; set; }
    }
}
