﻿using System;

using UIKit;

namespace Kudo.iOS
{
    public partial class PlusItemController : UIViewController
    {
        public ItemsViewModel ViewModel { get; set; }

        public PlusItemController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnSaveItem.TouchUpInside += (sender, e) =>
            {
                var item = new Item
                {
                    Text = txtTitle.Text,
                    Description = txtDesc.Text
                };
                ViewModel.AddItemCommand.Execute(item);
                NavigationController.PopToRootViewController(true);
            };
        }
    }
}
