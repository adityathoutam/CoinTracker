using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace CoinTracker
{
    public class MarketRatesFragment : Fragment
    {
        private int position;
        TextView bitcoinpriceview;
        TextView bitcoinCASHpriceview;
        TextView litecoinpriceview;
        TextView dashpriceview;


        public static MarketRatesFragment NewInstance(int position)
        {
            var f = new MarketRatesFragment();
            var b = new Bundle();
            b.PutInt("position", position);
            f.Arguments = b;
            return f;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            position = Arguments.GetInt("position");
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var root = inflater.Inflate(Resource.Layout.MarketRatesFragment, container, false);

            bitcoinCASHpriceview = root.FindViewById<TextView>(Resource.Id.bitcoinpricerightnowVIEW);
            bitcoinCASHpriceview.Text = CoinTracker.Program.tracker(0, true);

            bitcoinpriceview = root.FindViewById<TextView>(Resource.Id.bitcoincashpricerightnowVIEW);
            bitcoinpriceview.Text = CoinTracker.Program.tracker(1, true);

            litecoinpriceview = root.FindViewById<TextView>(Resource.Id.litecoinpricerightnowVIEW);
            litecoinpriceview.Text = CoinTracker.Program.tracker(2, true);

            dashpriceview = root.FindViewById<TextView>(Resource.Id.DASHcoinpricerightnowVIEW);
            dashpriceview.Text = CoinTracker.Program.tracker(3, true);



            return root;
        }

    }
}