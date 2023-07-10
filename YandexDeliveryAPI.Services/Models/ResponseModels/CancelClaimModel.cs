using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexDeliveryAPI.Services.Models.ResponseModels
{
    public sealed class CancelClaimModel
    {
        public string id { get; set; }
        public string status { get; set; }
        public int version { get; set; }
        public string user_request_revision { get; set; }
        public bool skip_client_notify { get; set; }

        public string code { get; set; }
        public string message { get; set; }
    }

}
