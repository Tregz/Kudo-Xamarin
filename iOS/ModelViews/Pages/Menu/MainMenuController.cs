using System;
using Xamarin.SideMenu;

using UIKit;

namespace Kudo.iOS.ModelViews.Pages.Menu
{
    public partial class MainMenuController : UINavigationController
    {
        private SideMenuManager smm;
        private UITableViewController leftSide;
        private UITableViewController userSide;

        public MainMenuController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TopViewController.NavigationItem.SetLeftBarButtonItem(
                new UIBarButtonItem("Menu", UIBarButtonItemStyle.Plain, (sender, e) =>
                PresentViewController(smm.LeftNavigationController, true, null)
            ), false);

            TopViewController.NavigationItem.SetRightBarButtonItem(
                new UIBarButtonItem("User", UIBarButtonItemStyle.Plain, (sender, e) =>
                PresentViewController(smm.RightNavigationController, true, null)
            ), false);

            smm = new SideMenuManager();
            leftSide = Controller(nameof(LeftMenuController));
            userSide = Controller(nameof(UserMenuController));
            smm.LeftNavigationController = Side(leftSide, true);
            smm.RightNavigationController = Side(userSide, false);
            UINavigationController nc = TopViewController.NavigationController;
            smm.AddPanGestureToPresent(toView: nc?.NavigationBar);
            smm.AddScreenEdgePanGesturesToPresent(toView: nc?.View);
            smm.BlurEffectStyle = null;
            smm.AnimationFadeStrength = 5d;
            smm.ShadowOpacity = 5d;
            smm.AnimationTransformScaleFactor = 5d;
            smm.FadeStatusBar = true;
        }

        private UIBarButtonItem Menu(UISideMenuNavigationController nc, string title) =>
            new UIBarButtonItem(title, UIBarButtonItemStyle.Plain, (sender, e) =>
                PresentViewController(nc, true, null));

        private UISideMenuNavigationController Side(UIViewController vc, bool left) =>
            new UISideMenuNavigationController(smm, vc, leftSide: left);

        private UITableViewController Controller(string id) =>
            (UITableViewController)Storyboard.InstantiateViewController(id);
    }
}

