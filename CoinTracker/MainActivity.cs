using Android.App;
using Android.Widget;
using Android.OS;
using System;

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

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.Currency_Array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

        }
      
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            switch (spinner.GetItemIdAtPosition(e.Position))
            {
                case 1:
                    string btctoast = string.Format("Bitcoin is {0}", Core.Program.tacker(0));
                    Toast.MakeText(this, btctoast, ToastLength.Long).Show();
                    break;
                case 2:
                    string bchtoast = string.Format("Bitcoin Cash is {0}", Core.Program.tacker(1));
                    Toast.MakeText(this, bchtoast, ToastLength.Long).Show();
                    break;
                case 3:
                    string ltctoast = string.Format("Litecoin is {0}", Core.Program.tacker(2));
                    Toast.MakeText(this, ltctoast, ToastLength.Long).Show();
                    break;
                case 4:
                    string dashtoast = string.Format("Dash is {0}", Core.Program.tacker(3));
                    Toast.MakeText(this, dashtoast, ToastLength.Long).Show();
                    break;
            }

        }




    }
}


