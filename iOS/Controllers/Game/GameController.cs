using System;

using UIKit;

namespace Kudo.iOS.Controllers.Game
{
    public partial class GameController : UIViewController
    {
        public GameViewModel ViewModel { get; set; }
        public GameController() : base("GameController", null)
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
