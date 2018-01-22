using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientSample
{
    public class Welcome
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

    public  class Inr
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

        static void Main(string[] args)
        {
            var currencyRates = _download_serialized_json_data<Welcome>();
            Console.WriteLine("How much bitcoin did you buy?");
            
            string a = currencyRates.BTC.Last;

            Console.WriteLine(a);
            Console.Read();
        }
        
        private static T _download_serialized_json_data<T>()where T : new()
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