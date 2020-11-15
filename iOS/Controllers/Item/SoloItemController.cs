using System;
using UIKit;

namespace Kudo.iOS
{
    public partial class SoloItemController : UIViewController
    {
        public ItemDetailViewModel ViewModel { get; set; }
        public SoloItemController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
            ItemNameLabel.Text = ViewModel.Item.Text;
            ItemDescriptionLabel.Text = ViewModel.Item.Description;
        }
    }
}
