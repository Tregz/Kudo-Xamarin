// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Kudo.iOS
{
    [Register ("GameController")]
    partial class GameController
    {
        [Outlet]
        UIKit.UICollectionView Grid { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView AboutImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView AboutTextView { get; set; }


        [Action ("ReadMoreButton_TouchUpInside:")]
        partial void ReadMoreButton_TouchUpInside (UIKit.UIButton sender);


        [Action ("Validate:")]
        partial void Validate (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AboutImageView != null) {
                AboutImageView.Dispose ();
                AboutImageView = null;
            }

            if (AboutTextView != null) {
                AboutTextView.Dispose ();
                AboutTextView = null;
            }
        }
    }
}