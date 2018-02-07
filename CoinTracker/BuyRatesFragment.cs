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
   
    public class BuyRatesFragment :Fragment
    {
        private int position;
        TextView currentprice;
        EditText quantity;
        EditText price;
        TextView marginview;
        public static BuyRatesFragment NewInstance(int position)
        {
            var f = new BuyRatesFragment();
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
            var root = inflater.Inflate(Resource.Layout.BuyRatesFragment, container, false);

            Spinner spinner = root.FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            currentprice = root.FindViewById<TextView>(Resource.Id.currentprice);
            quantity = root.FindViewById<EditText>(Resource.Id.quantity);
            price = root.FindViewById<EditText>(Resource.Id.price);
            marginview = root.FindViewById<TextView>(Resource.Id.marginview);

            var adapter = ArrayAdapter.CreateFromResource( container.Context, Resource.Array.Currency_Array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            return root;

        }
       
      
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
           


            switch (spinner.GetItemIdAtPosition(e.Position))

            {
                case 1:
                    
                    string btctoast =Convert.ToString(CoinTracker.Program.margin(quantity.Text, price.Text, CoinTracker.Program.tracker(0)));
                    
                    currentprice.Text = CoinTracker.Program.tracker(0);
                    marginview.Text = btctoast;
                    break;
                case 2:
                    string bchtoast = Convert.ToString(CoinTracker.Program.margin(quantity.Text, price.Text, CoinTracker.Program.tracker(1)));
                    
                    currentprice.Text = CoinTracker.Program.tracker(1);
                    marginview.Text = bchtoast;
                    break;
                case 3:
                    string ltctoast = Convert.ToString(CoinTracker.Program.margin(quantity.Text, price.Text, CoinTracker.Program.tracker(2)));
                    
                    currentprice.Text = CoinTracker.Program.tracker(2);
                    marginview.Text = ltctoast;

                    break;
                case 4:
                    string dashtoast = Convert.ToString(CoinTracker.Program.margin(quantity.Text, price.Text, CoinTracker.Program.tracker(3)));
                    currentprice.Text = CoinTracker.Program.tracker(3);
                    marginview.Text = dashtoast;
                    break;
            }

        }




    }
}


