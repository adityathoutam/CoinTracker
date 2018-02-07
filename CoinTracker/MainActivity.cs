using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Java.Lang;
using com.refractored;
using Android.Support.V4.View;
using Android.Support.V7.App;

namespace CoinTracker
{
    [Activity(Label = "CoinTracker", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        MyAdapter adapter;
        PagerSlidingTabStrip tabs;
        ViewPager pager;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            adapter = new MyAdapter(SupportFragmentManager);
            pager = FindViewById<ViewPager>(Resource.Id.pager);
            tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);
            pager.Adapter = adapter;
            tabs.SetViewPager(pager);
            tabs.SetBackgroundColor(Android.Graphics.Color.Argb(255, 47, 59, 162));

        }

        public class MyAdapter : FragmentPagerAdapter
        {
            int tabCount = 3;
            public MyAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
            {

            }
            public override int Count
            {
                get
                {
                    return tabCount;
                }
            }
            public override ICharSequence GetPageTitleFormatted(int position)
            {
                ICharSequence cs;
                if (position == 0)
                    cs = new Java.Lang.String("Market Rates");
                else if (position == 1)
                    cs = new Java.Lang.String("Buy Rates");
                else
                    cs = new Java.Lang.String("Sell Rates");
                return cs;
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return BuyRatesFragment.NewInstance(0);


            }
        }
    }
}

