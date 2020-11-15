using System;
using UIKit;

namespace Kudo.iOS
{
    public partial class MenuController : UITabBarController
    {
        public MenuController(IntPtr handle) : base(handle)
        {
            TabBar.Items[0].Title = "Browse";
            TabBar.Items[1].Title = "About";
        }
    }
}
