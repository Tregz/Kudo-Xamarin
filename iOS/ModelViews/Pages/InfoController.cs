using System;
using UIKit;

namespace Kudo.iOS
{
    public partial class InfoController : UIViewController
    {
        public InfoViewModel ViewModel { get; set; }
        public InfoController(IntPtr handle) : base(handle)
        {
            ViewModel = new InfoViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;

            AppNameLabel.Text = "Kudo";
            VersionLabel.Text = "1.0";
            AboutTextView.Text = "This app is written in C# and native APIs using the Xamarin Platform. It shares code with its iOS, Android, & Windows versions.";
        }

        partial void ReadMoreButton_TouchUpInside(UIButton sender) => ViewModel.OpenWebCommand.Execute(null);
    }
}
