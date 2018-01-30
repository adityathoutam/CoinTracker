using System;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;

namespace Core
{

    public class StringConv
    {
        [JsonProperty("BTC-INR")]
        public Inr BTC { get; set; }

        [JsonProperty("BCH-INR")]
        public Inr BCH { get; set; }

        [JsonProperty("LTC-INR")]
        public Inr LTC { get; set; }

        [JsonProperty("DASH-INR")]
        public Inr DASH { get; set; }
    }
    public class Inr
    {
        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("lowest_ask")]
        public string LowestAsk { get; set; }

        [JsonProperty("highest_bid")]
        public string HighestBid { get; set; }
    }
    class Program
    {
        
        public static string tacker(int i)
        {
            var currencyRates = _download_serialized_json_data<StringConv>();
            switch (i)
            {
                case 0:
                    string BTC = currencyRates.BTC.LowestAsk;
                    return BTC;
                   

                case 1:
                    string BCH = currencyRates.BCH.LowestAsk;
                    return BCH;

                case 2:
                    string LTC = currencyRates.LTC.LowestAsk;
                    return LTC;

                case 3:
                    string DASH = currencyRates.DASH.LowestAsk;
                    return DASH;

                default:
                    return null;
            }

        }

      

        

        public static T _download_serialized_json_data<T>() where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    json_data = w.DownloadString("https://www.coinome.com/api/v1/ticker.json");
                }
                catch (Exception) { }
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}