using System;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Kudo.Droid
{
    public class InfoFragment : AndroidX.Fragment.App.Fragment, BaseFragment
    {
        public static InfoFragment NewInstance() =>
            new InfoFragment { Arguments = new Bundle() };

        public InfoViewModel ViewModel { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        Button learnMoreButton;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_info, container, false);
            ViewModel = new InfoViewModel();
            learnMoreButton = view.FindViewById<Button>(Resource.Id.button_learn_more);
            return view;
        }

        public override void OnStart()
        {
            base.OnStart();
            learnMoreButton.Click += LearnMoreButton_Click;
        }

        public override void OnStop()
        {
            base.OnStop();
            learnMoreButton.Click -= LearnMoreButton_Click;
        }

        public void BecameVisible()
        {

        }

        void LearnMoreButton_Click(object sender, EventArgs e)
        {
            ViewModel.OpenWebCommand.Execute(null);
        }
    }
}
