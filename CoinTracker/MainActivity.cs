using Android.App;
using Android.Widget;
using Android.OS;

namespace CoinTracker
{
    [Activity(Label = "CoinTracker", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button getabllbutton = FindViewById<Button>(Resource.Id.getallbutton);
            TextView btc = FindViewById<TextView>(Resource.Id.btcview);
            TextView bch = FindViewById<TextView>(Resource.Id.bchview);
            TextView ltc = FindViewById<TextView>(Resource.Id.ltcview);
            TextView dash = FindViewById<TextView>(Resource.Id.dashview);



            getabllbutton.Click += (sender, e) =>
            {

                string btcreturn = Core.Program.tacker(1);
                btc.Text = btcreturn;
                string bchreturn = Core.Program.tacker(2);
                bch.Text = bchreturn;
                string ltcreturn = Core.Program.tacker(3);
                ltc.Text = ltcreturn;
                string dashreturn = Core.Program.tacker(4);
                dash.Text = dashreturn;
            };


       }
    }
}


