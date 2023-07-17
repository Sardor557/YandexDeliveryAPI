using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexDeliveryAPI.Services.Models.ResponseModels
{
    public class ClaimInfoModel
    {
        public string available_cancel_state { get; set; }
        public Callback_Properties callback_properties { get; set; }
        public Carrier_Info carrier_info { get; set; }
        public client_Requirements client_requirements { get; set; }
        public string comment { get; set; }
        public string corp_client_id { get; set; }
        public string created_ts { get; set; }
        public int current_point_id { get; set; }
        public string due { get; set; }
        public emergency_Contact emergency_contact { get; set; }
        public error_Messages[] error_messages { get; set; }
        public int eta { get; set; }
        public string id { get; set; }
        public item[] items { get; set; }
        public matched_Cars[] matched_cars { get; set; }
        public bool optional_return { get; set; }
        public performer_Info performer_info { get; set; }
        public pricing pricing { get; set; }
        public int revision { get; set; }
        public string route_id { get; set; }
        public route_Points[] route_points { get; set; }
        public same_Day_Data same_day_data { get; set; }
        public string shipping_document { get; set; }
        public bool skip_act { get; set; }
        public bool skip_client_notify { get; set; }
        public bool skip_door_to_door { get; set; }
        public bool skip_emergency_notify { get; set; }
        public string status { get; set; }
        public taxi_Offer taxi_offer { get; set; }
        public string updated_ts { get; set; }
        public string user_request_revision { get; set; }
        public int version { get; set; }
        public warning[] warnings { get; set; }

        public string code { get; set; }
        public string message { get; set; }
        public string claim_id { get; set; }
    }

    public class Callback_Properties
    {
        public string callback_url { get; set; }
    }

    public class Carrier_Info
    {
        public string address { get; set; }
        public string inn { get; set; }
        public string name { get; set; }
    }

    public class client_Requirements
    {
        public bool assign_robot { get; set; }
        public int cargo_loaders { get; set; }
        public string[] cargo_options { get; set; }
        public string cargo_type { get; set; }
        public bool pro_courier { get; set; }
        public string taxi_class { get; set; }
    }

    public class emergency_Contact
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string phone_additional_code { get; set; }
    }

    public class performer_Info
    {
        public string car_color { get; set; }
        public string car_color_hex { get; set; }
        public string car_model { get; set; }
        public string car_number { get; set; }
        public string courier_name { get; set; }
        public string legal_name { get; set; }
        public string transport_type { get; set; }
    }

    public class pricing
    {
        public string currency { get; set; }
        public Currency_Rules currency_rules { get; set; }
        public string final_price { get; set; }
        public string final_pricing_calc_id { get; set; }
        public Offer offer { get; set; }
    }

    public class Currency_Rules
    {
        public string code { get; set; }
        public string sign { get; set; }
        public string template { get; set; }
        public string text { get; set; }
    }

    public class Offer
    {
        public string offer_id { get; set; }
        public string price { get; set; }
        public int price_raw { get; set; }
        public string price_with_vat { get; set; }
        public string valid_until { get; set; }
    }

    public class same_Day_Data
    {
        public Delivery_Interval delivery_interval { get; set; }
    }

    public class Delivery_Interval
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class taxi_Offer
    {
        public string offer_id { get; set; }
        public string price { get; set; }
        public int price_raw { get; set; }
    }

    public class error_Messages
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class item
    {
        public string cost_currency { get; set; }
        public string cost_value { get; set; }
        public int droppof_point { get; set; }
        public string extra_id { get; set; }
        public Fiscalization fiscalization { get; set; }
        public int pickup_point { get; set; }
        public int quantity { get; set; }
        public size size { get; set; }
        public string title { get; set; }
        public float weight { get; set; }
    }

    public class Fiscalization
    {
        public string article { get; set; }
        public string excise { get; set; }
        public string item_type { get; set; }
        public Mark mark { get; set; }
        public string supplier_inn { get; set; }
        public string vat_code_str { get; set; }
    }

    public class Mark
    {
        public string code { get; set; }
        public string kind { get; set; }
    }

    public class size
    {
        public float height { get; set; }
        public float length { get; set; }
        public float width { get; set; }
    }

    public class matched_Cars
    {
        public int cargo_loaders { get; set; }
        public string cargo_type { get; set; }
        public int cargo_type_int { get; set; }
        public string client_taxi_class { get; set; }
        public bool door_to_door { get; set; }
        public bool pro_courier { get; set; }
        public string taxi_class { get; set; }
    }

    public class route_Points
    {
        public address address { get; set; }
        public contact contact { get; set; }
        public external_Order_Cost external_order_cost { get; set; }
        public string external_order_id { get; set; }
        public int id { get; set; }
        public bool leave_under_door { get; set; }
        public bool meet_outside { get; set; }
        public bool modifier_age_check { get; set; }
        public bool no_door_call { get; set; }
        public payment_On_Delivery payment_on_delivery { get; set; }
        public string pickup_code { get; set; }
        public string return_comment { get; set; }
        public string[] return_reasons { get; set; }
        public bool skip_confirmation { get; set; }
        public string type { get; set; }
        public int visit_order { get; set; }
        public string visit_status { get; set; }
        public visited_At visited_at { get; set; }
    }

    public class address
    {
        public string building { get; set; }
        public string building_name { get; set; }
        public string city { get; set; }
        public string comment { get; set; }
        public float[] coordinates { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public string door_code { get; set; }
        public string door_code_extra { get; set; }
        public string doorbell_name { get; set; }
        public int flat { get; set; }
        public int floor { get; set; }
        public string fullname { get; set; }
        public string porch { get; set; }
        public string sflat { get; set; }
        public string sfloor { get; set; }
        public string shortname { get; set; }
        public string street { get; set; }
        public string uri { get; set; }
    }

    public class contact
    {
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string phone_additional_code { get; set; }
    }

    public class external_Order_Cost
    {
        public string currency { get; set; }
        public string currency_sign { get; set; }
        public string value { get; set; }
    }

    public class payment_On_Delivery
    {
        public string client_order_id { get; set; }
        public string cost { get; set; }
        public customer customer { get; set; }
        public bool is_paid { get; set; }
        public string payment_method { get; set; }
        public string payment_ref_id { get; set; }
    }

    public class customer
    {
        public string email { get; set; }
        public string full_name { get; set; }
        public string inn { get; set; }
        public string phone { get; set; }
    }

    public class visited_At
    {
        public string actual { get; set; }
        public string expected { get; set; }
        public int expected_waiting_time_sec { get; set; }
    }

    public class warning
    {
        public string code { get; set; }
        public string message { get; set; }
        public string source { get; set; }
    }

}
