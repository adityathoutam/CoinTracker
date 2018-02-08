using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CoinTracker
{
    public class SellRatesFragment : Fragment
    {
        public static SellRatesFragment NewInstance(int position)
        {
            var f = new SellRatesFragment();
            var b = new Bundle();
            b.PutInt("position", position);
            f.Arguments = b;
            return f;
        }
    }
}