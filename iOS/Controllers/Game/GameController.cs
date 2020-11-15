using System;

using UIKit;

namespace Kudo.iOS
{
    public partial class GameController : UIViewController
    {
        public GameViewModel ViewModel { get; set; }

        public GameController(IntPtr handle) : base(handle)
        {
            ViewModel = new GameViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
            AppNameLabel.Text = "Game";
        }
    }
}
