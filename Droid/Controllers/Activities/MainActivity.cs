﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.ViewPager.Widget;
using Google.Android.Material.Tabs;

namespace Kudo.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@mipmap/icon",
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
    {
        protected override int LayoutResource => Resource.Layout.activity_main;

        ViewPager pager;
        TabsAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            adapter = new TabsAdapter(this, SupportFragmentManager);
            pager = FindViewById<ViewPager>(Resource.Id.viewpager);
            var tabs = FindViewById<TabLayout>(Resource.Id.tabs);
            pager.Adapter = adapter;
            tabs.SetupWithViewPager(pager);
            pager.OffscreenPageLimit = 3;

            pager.PageSelected += (sender, args) =>
            {
                var fragment = adapter.InstantiateItem(pager, args.Position) as BaseFragment;

                fragment?.BecameVisible();
            };

            Toolbar.MenuItemClick += (sender, e) =>
            {
                var intent = new Intent(this, typeof(PlusItemActivity)); ;
                StartActivity(intent);
            };

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }

    class TabsAdapter : FragmentStatePagerAdapter
    {
        string[] titles;

        public override int Count => titles.Length;

        public TabsAdapter(Context context, AndroidX.Fragment.App.FragmentManager fm) : base(fm)
        {
            titles = context.Resources.GetTextArray(Resource.Array.sections);
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position) =>
                            new Java.Lang.String(titles[position]);

        public override AndroidX.Fragment.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0: return GameFragment.NewInstance();
                case 1: return ListFragment.NewInstance();
                case 2: return InfoFragment.NewInstance();
            }
            return null;
        }

        public override int GetItemPosition(Java.Lang.Object frag) => PositionNone;
    }
}
