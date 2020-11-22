using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.Design.Widget;

namespace Kudo.Droid
{
    [Activity(Label = "Add")]
    public class PlusItemActivity : Activity
    {
        FloatingActionButton saveButton;
        EditText title, description;

        public ListViewModel ViewModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ViewModel = ListFragment.ViewModel;

            // Create your application here
            SetContentView(Resource.Layout.activity_add_item);
            saveButton = FindViewById<FloatingActionButton>(Resource.Id.save_button);
            title = FindViewById<EditText>(Resource.Id.txtTitle);
            description = FindViewById<EditText>(Resource.Id.txtDesc);

            saveButton.Click += SaveButton_Click;
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            var item = new Game
            {
                Text = title.Text,
                Description = description.Text
            };
            ViewModel.AddItemCommand.Execute(item);

            Finish();
        }
    }
}
