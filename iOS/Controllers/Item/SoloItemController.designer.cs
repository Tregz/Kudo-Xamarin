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
    [Register ("SoloItemController")]
    partial class SoloItemController
    {
        [Outlet]
        UIKit.UILabel GameDescriptionLabel { get; set; }


        [Outlet]
        UIKit.UIPickerView GameLevelPicker { get; set; }


        [Outlet]
        UIKit.UIButton GameLoadButton { get; set; }


        [Outlet]
        UIKit.UILabel GameNameLabel { get; set; }


        [Outlet]
        UIKit.UILabel GameSuccessesLabel { get; set; }


        [Action ("GameLoadAction:")]
        partial void GameLoadAction (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}