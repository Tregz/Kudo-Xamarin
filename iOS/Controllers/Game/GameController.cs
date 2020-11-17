using System;
using System.Collections.Generic;
using UIKit;

namespace Kudo.iOS
{
    public partial class GameController : UIViewController
    {

        public static readonly string CellIdentifier = "GameCell";

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
            List<int[,]> list = ViewModel.Sudoku;
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

            Grid.Delegate = new GridDelegate(this);
            Grid.DataSource = new GridDataSource(ViewModel, list);

        }
    }

    class GridDataSource : UICollectionViewSource
    {
        //static readonly NSString CELL_IDENTIFIER = new NSString("ITEM_CELL");

        GameViewModel viewModel;
        List<int[,]> list;

        public GridDataSource(GameViewModel viewModel, List<int[,]> list)
        {
            this.viewModel = viewModel;
            this.list = list;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return list.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath) {
            UICollectionViewCell cell = collectionView.DequeueReusableCell(GameController.CellIdentifier, indexPath) as UICollectionViewCell;
            cell.BackgroundColor = UIColor.Red;
            UIStackView vsv1 = new UIStackView();
            //vsv1.BackgroundColor = UIColor.Orange;
            vsv1.Axis = UILayoutConstraintAxis.Vertical;
            vsv1.Distribution = UIStackViewDistribution.EqualSpacing;
            vsv1.Frame = cell.Bounds;
            nfloat rowWidth = vsv1.Frame.Size.Width;
            nfloat rowHeight = vsv1.Frame.Size.Height / 3;
            UIStackView hsv1 = new UIStackView();
            //hsv1.BackgroundColor = UIColor.Green;
            hsv1.Axis = UILayoutConstraintAxis.Horizontal;
            hsv1.Distribution = UIStackViewDistribution.EqualSpacing;
            //hsv1.Alignment = UIStackViewAlignment.Center;
            hsv1.WidthAnchor.ConstraintEqualTo(rowWidth).Active = true;
            hsv1.HeightAnchor.ConstraintEqualTo(rowHeight).Active = true;
            //horizontal1StackView.TranslatesAutoresizingMaskIntoConstraints = false;
            UIStackView hsv2 = new UIStackView();
            //hsv2.BackgroundColor = UIColor.Purple;
            hsv2.Axis = UILayoutConstraintAxis.Horizontal;
            //horizontal2StackView.Alignment = UIStackViewAlignment.Fill;
            hsv2.Distribution = UIStackViewDistribution.EqualSpacing;
            hsv2.WidthAnchor.ConstraintEqualTo(rowWidth).Active = true;
            hsv2.HeightAnchor.ConstraintEqualTo(rowHeight).Active = true;
            //horizontal2StackView.TranslatesAutoresizingMaskIntoConstraints = false;
            UIStackView hsv3 = new UIStackView();
            hsv3.Axis = UILayoutConstraintAxis.Horizontal;
            //hsv3.BackgroundColor = UIColor.Blue;
            //horizontal3StackView.Alignment = UIStackViewAlignment.Fill;
            hsv3.Distribution = UIStackViewDistribution.EqualSpacing;
            hsv3.WidthAnchor.ConstraintEqualTo(rowWidth).Active = true;
            hsv3.HeightAnchor.ConstraintEqualTo(rowHeight).Active = true;
            //horizontal3StackView.TranslatesAutoresizingMaskIntoConstraints = false;
            vsv1.AddArrangedSubview(hsv1);
            vsv1.AddArrangedSubview(hsv2);
            vsv1.AddArrangedSubview(hsv3);
            //cell.ContentView.AddSubview(verticalStackView);
            cell.ContentView.AddSubview(vsv1);

            int i = 0;
            foreach (int value in list[indexPath.Row])
            {

                UITextView textView = new UITextView();
                textView.Text = value.ToString();
                textView.TextAlignment = UITextAlignment.Center;
                switch (i++)
                {
                    case 0:
                    case 1:
                    case 2:
                        textView.WidthAnchor.ConstraintEqualTo(rowWidth / 4).Active = true;
                        textView.HeightAnchor.ConstraintEqualTo(rowHeight).Active = true;
                        hsv1.AddArrangedSubview(textView);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        textView.WidthAnchor.ConstraintEqualTo(rowWidth / 4).Active = true;
                        textView.HeightAnchor.ConstraintEqualTo(rowHeight).Active = true;
                        hsv2.AddArrangedSubview(textView);
                        break;
                    case 6:
                    case 7:
                    case 8:
                        textView.WidthAnchor.ConstraintEqualTo(rowWidth / 4).Active = true;
                        textView.HeightAnchor.ConstraintEqualTo(rowHeight).Active = true;
                        hsv3.AddArrangedSubview(textView);
                        break;
                    default:
                        break;
                }
            }
            return cell;
        }

    }

    public class GridDelegate : UICollectionViewDelegateFlowLayout
    {
        private UIViewController controller;

        public GridDelegate(UIViewController controller)
        {
            this.controller = controller;
        }

        public override CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            CoreGraphics.CGRect screenRect = UIScreen.MainScreen.Bounds;
            return new CoreGraphics.CGSize(width: (screenRect.Size.Width/3)-10, height: 70.0);
        }
    }
}
