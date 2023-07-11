using Newtonsoft.Json;
using System;
using YandexDeliveryAPI.Services.Models.ResponseModels;

namespace YandexDeliveryAPI.Services.Models.RequestModels
{
    public class ClaimModel
    {
        public Client_Requirements client_requirements { get; set; }
        public Callback_Properties callback_properties { get; set; }
        public string comment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? due { get; set; }
        public Emergency_Contact emergency_contact { get; set; }
        public Item[] items { get; set; }
        public bool optional_return { get; set; }
        public string referral_source { get; set; }
        public Route_Points[] route_points { get; set; }
        public bool skip_act { get; set; }
        public bool skip_client_notify { get; set; }
        public bool skip_door_to_door { get; set; }
        public bool skip_emergency_notify { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Guid { get; set; }
    }

    public class Client_Requirements
    {
        public bool assign_robot { get; set; }
        public bool pro_courier { get; set; }
        public string taxi_class { get; set; }
    }

    public class Emergency_Contact
    {
        public string name { get; set; }
        public string phone { get; set; }
    }

    public class Item
    {
        public string cost_currency { get; set; }
        public string cost_value { get; set; }
        public int droppof_point { get; set; }
        public string extra_id { get; set; }
        public int pickup_point { get; set; }
        public int quantity { get; set; }
        public Size size { get; set; }
        public string title { get; set; }
        public int weight { get; set; }
    }

    public class Size
    {
        public float height { get; set; }
        public float length { get; set; }
        public float width { get; set; }
    }

    public class Route_Points
    {
        public Address address { get; set; }
        public Contact contact { get; set; }
        public External_Order_Cost external_order_cost { get; set; }
        public string external_order_id { get; set; }
        public string pickup_code { get; set; }
        public int point_id { get; set; }
        public bool skip_confirmation { get; set; }
        public string type { get; set; }
        public int visit_order { get; set; }
    }

    public class Address
    {
        public float[] coordinates { get; set; }
        public string building { get; set; }
        public string building_name { get; set; }
        public string city { get; set; }
        public string comment { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public string door_code { get; set; }
        public string door_code_extra { get; set; }
        public string doorbell_name { get; set; }
        public string fullname { get; set; }
        public string porch { get; set; }
        public string sflat { get; set; }
        public string sfloor { get; set; }
    }

    public class Contact
    {
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }

    public class External_Order_Cost
    {
        public string currency { get; set; }
        public string currency_sign { get; set; }
        public string value { get; set; }
    }

}
