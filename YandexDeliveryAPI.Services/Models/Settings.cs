using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexDeliveryAPI.Services.Models
{
    public sealed class Settings
    {
        public string Y_TOKEN { get; set; }
        public string CreateClaimUrl { get; set; }
        public string DeliveryStatusUrl { get; set; }
        public string CancelClaimUrl { get; set; }
        public string ConfirmClaimUrl { get; set; }
    }
}
