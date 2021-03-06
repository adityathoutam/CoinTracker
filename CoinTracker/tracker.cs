﻿using System;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;

namespace CoinTracker
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
        
        public static string tracker(int i,bool High)
        {
            var currencyRates = _download_serialized_json_data<StringConv>();
            switch (i)
            {
                case 0:
                    string BTC;
                    if (High == false)
                        BTC = currencyRates.BTC.LowestAsk;
                   else BTC =currencyRates.BTC.HighestBid;
                        return BTC;
                   

                case 1:
                    string BCH;
                    if (High == false)
                         BCH = currencyRates.BCH.LowestAsk;
                    else BCH = currencyRates.BCH.HighestBid;
                        return BCH;

                case 2:
                    string LTC;
                    if (High == false)
                         LTC = currencyRates.LTC.LowestAsk;
                    else LTC = currencyRates.LTC.HighestBid;
                    return LTC;

                case 3:
                    string DASH;
                    if (High == false)
                        DASH = currencyRates.DASH.LowestAsk;
                    else DASH = currencyRates.DASH.HighestBid;
                    return DASH;

                default:
                    return null;
            }

        }

      
        public static float margin(string Bquantity, string Bprice, string CurrentPrice)
        {
            float FloatBprice = float.Parse(Bprice, CultureInfo.InvariantCulture.NumberFormat);
            float FloatBquantity = float.Parse(Bquantity, CultureInfo.InvariantCulture.NumberFormat);
            float FloatCurrentPrice = float.Parse(CurrentPrice, CultureInfo.InvariantCulture.NumberFormat);
            float FloatBoughtPrice = FloatBprice / FloatBquantity;


           
            float Margin = (FloatCurrentPrice - FloatBoughtPrice) * FloatBquantity;

            return Margin ;
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