using System;
using Xamarin.Essentials;
using UIKit;

namespace Kudo.iOS
{
    public partial class SoloItemController : UIViewController
    {
        public SoloViewModel ViewModel { get; set; }
        public SoloItemController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
            GameNameLabel.Text = ViewModel.Item.Text;
            GameLoadButton.SetTitle("Current", UIControlState.Disabled);
            if (ViewModel.Item.Guid == Preferences.Get("game", "0"))
                GameLoadButton.Enabled = false;
            GameDescriptionLabel.Text = ViewModel.Item.Description;
            GameLevelPicker.Model = new LevelModel(ViewModel);
            GameLevelPicker.Select(ViewModel.Item.Level, 0, true);
            GameSuccessesLabel.Text += ": " + ViewModel.Item.Successes;
        }

        partial void GameLoadAction(UIButton sender)
        {
            Preferences.Set("game", ViewModel.Item.Guid);
            GameLoadButton.Enabled = false;
        }
    }

    class LevelModel : UIPickerViewModel
    {
        public string[] levels = new string[] {
            "Easy",
            "Normal",
            "Hard"
        };

        readonly SoloViewModel viewModel;

        public LevelModel(SoloViewModel viewModel) {
            this.viewModel = viewModel;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return levels.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (component == 0) return levels[row];
            else return row.ToString();
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            viewModel.Item.Level = (int)row;
        }
    }
}
