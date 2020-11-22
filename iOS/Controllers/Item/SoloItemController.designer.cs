// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
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
			if (GameDescriptionLabel != null) {
				GameDescriptionLabel.Dispose ();
				GameDescriptionLabel = null;
			}

			if (GameLevelPicker != null) {
				GameLevelPicker.Dispose ();
				GameLevelPicker = null;
			}

			if (GameNameLabel != null) {
				GameNameLabel.Dispose ();
				GameNameLabel = null;
			}

			if (GameSuccessesLabel != null) {
				GameSuccessesLabel.Dispose ();
				GameSuccessesLabel = null;
			}

			if (GameLoadButton != null) {
				GameLoadButton.Dispose ();
				GameLoadButton = null;
			}
		}
	}
}
