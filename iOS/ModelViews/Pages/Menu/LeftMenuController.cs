using System;

using UIKit;

namespace Kudo.iOS.ModelViews.Pages.Menu
{
    public partial class LeftMenuController : UITableViewController
    {

        public LeftMenuController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			//this.TableView.RegisterClassForCellReuse(typeof(UITableViewVibrantCell), "VibrantCell");
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

		/* public override nint RowsInSection(UITableView tableView, nint section)
		{
			return 3;
		} */

		/* public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("VibrantCell");

			cell.TextLabel.Text = "Index " + indexPath.Row;

			return cell;
		} */

		/* public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);

			var rnd = new Random(Guid.NewGuid().GetHashCode());

			var vc = new UIViewController() { };
			vc.View.BackgroundColor = UIColor.FromRGB(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

			this.ShowViewController(vc, this);
		} */
	}
}

