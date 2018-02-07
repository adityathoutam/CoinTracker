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
            TextView currentprice = FindViewById<TextView>(Resource.Id.currentprice);
            EditText quantity = FindViewById<EditText>(Resource.Id.quantity);
            EditText price = FindViewById<EditText>(Resource.Id.price);
            TextView marginview = FindViewById<TextView>(Resource.Id.marginview);


            switch (spinner.GetItemIdAtPosition(e.Position))

            {
                case 1:
                    
                    string btctoast =Convert.ToString(Core.Program.margin(quantity.Text, price.Text, Core.Program.tracker(0)));
                    Toast.MakeText(this, btctoast, ToastLength.Long).Show();
                    currentprice.Text = Core.Program.tracker(0);
                    marginview.Text = btctoast;
                    break;
                case 2:
                    string bchtoast = Convert.ToString(Core.Program.margin(quantity.Text, price.Text, Core.Program.tracker(1)));
                    Toast.MakeText(this, bchtoast, ToastLength.Long).Show();
                    currentprice.Text = Core.Program.tracker(1);
                    marginview.Text = bchtoast;
                    break;
                case 3:
                    string ltctoast = Convert.ToString(Core.Program.margin(quantity.Text, price.Text, Core.Program.tracker(2)));
                     Toast.MakeText(this, ltctoast, ToastLength.Long).Show();
                    currentprice.Text = Core.Program.tracker(2);
                    marginview.Text = ltctoast;

                    break;
                case 4:
                    string dashtoast = Convert.ToString(Core.Program.margin(quantity.Text, price.Text, Core.Program.tracker(3)));
                     Toast.MakeText(this, dashtoast, ToastLength.Long).Show();
                    currentprice.Text = Core.Program.tracker(3);
                    marginview.Text = dashtoast;
                    break;
            }

        }




    }
}


