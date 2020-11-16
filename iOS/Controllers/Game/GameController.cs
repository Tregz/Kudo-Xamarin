using System;
using System.Collections.Generic;
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
            List<int[,]> list = ViewModel.Grid;
            String numbers = "";
            foreach (int[,] grid in list)
            {
                foreach (int value in grid)
                {
                    numbers += value.ToString();
                }
                numbers += "-";
            }
            //AboutTextView.Text = ViewModel.IsTrue ? "True" :  "False";
            AboutTextView.Text = numbers;
        }
    }
}
