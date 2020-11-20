using System;
using System.Collections.Generic;
using UIKit;

namespace Kudo.iOS
{
    public partial class GameController : UIViewController, GameController.OnAnswerListener
    {

        public static readonly string CellIdentifier = "GameCell";

        public GameViewModel ViewModel { get; set; }

        public List<int[,]> Soluce { get; set; }
        public List<int[,]> Answers { get; set; }

        public GameController(IntPtr handle) : base(handle)
        {
            ViewModel = new GameViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = ViewModel.Title;
            Grid.Delegate = new GridDelegate(this);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            Start(false);
        }

        private void Start(Boolean reload)
        {
            if (reload) Grid.DataSource.Dispose();
            Soluce = ViewModel.Sudoku;
            Answers = new List<int[,]>();
            for (int i = 0; i < 9; i++) Answers.Add(new int[3, 3]);
            List<int[,]> puzzle = ViewModel.Puzzle;
            Grid.DataSource = new GridDataSource(ViewModel, puzzle, this);
            //Grid.LayoutIfNeeded();
        }

        private void ValidateResult(Boolean success)
        {
            String message = success ? "Success!" : "Failure!";
            var alert = UIAlertController.Create("Validation", message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            alert.AddAction(UIAlertAction.Create("Restart", UIAlertActionStyle.Destructive, (action) => Start(true)));
            PresentViewController(alert, true, null);
        }

        partial void Validate(UIButton sender)
        {
            int validatedCount = 0;
            int i = 0;
            foreach (int[,] grid in Answers) {
                int pos = 0;
                foreach (int value in grid)
                {
                    if (value > 0)
                    {
                        int col = pos;
                        int row = 0;
                        while (col > 2)
                        {
                            col -= 3;
                            row++;
                        }
                        if (value == Soluce[i][row, col]) validatedCount++;
                    }
                    pos++;
                }
                i++;
            }
            ValidateResult(validatedCount == ViewModel.HiddenCount);
        }

        void OnAnswerListener.OnAnswer(int grid, int row, int col, int value)
        {
            Answers[grid][row, col] = value;
        }

        public interface OnAnswerListener
        {
            void OnAnswer(int grid, int row, int col, int value);
        }
    }

    class GridDataSource : UICollectionViewSource
    {

        private GameViewModel viewModel;
        private List<int[,]> list;
        private GameController.OnAnswerListener listener;

        public GridDataSource(GameViewModel viewModel, List<int[,]> list, GameController.OnAnswerListener listener)
        {
            this.viewModel = viewModel;
            this.list = list;
            this.listener = listener;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return list.Count;
        }

        public UIView HorizontalBorder()
        {
            UIView border = new UIView();
            border.HeightAnchor.ConstraintEqualTo(3).Active = true;
            border.BackgroundColor = UIColor.Orange;
            return border;
        }

        public UIView VerticalBorder()
        {
            UIView border = new UIView();
            border.WidthAnchor.ConstraintEqualTo(2).Active = true;
            border.BackgroundColor = UIColor.Orange;
            return border;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath) {
            UICollectionViewCell cell = collectionView.DequeueReusableCell(GameController.CellIdentifier, indexPath) as UICollectionViewCell;
            foreach (UIView subView in cell.ContentView.Subviews) subView.RemoveFromSuperview();

            UIStackView vsv1 = new UIStackView();
            vsv1.Axis = UILayoutConstraintAxis.Vertical;
            vsv1.Distribution = UIStackViewDistribution.EqualSpacing;
            vsv1.Frame = cell.Bounds;
            nfloat rowWidth = vsv1.Frame.Size.Width;
            nfloat rowHeight = (vsv1.Frame.Size.Height / 3) - 4;
            UIStackView hsv1 = HorizontalStackView(rowWidth, rowHeight);
            UIStackView hsv2 = HorizontalStackView(rowWidth, rowHeight);
            UIStackView hsv3 = HorizontalStackView(rowWidth, rowHeight);
            vsv1.AddArrangedSubview(HorizontalBorder());
            vsv1.AddArrangedSubview(hsv1);
            vsv1.AddArrangedSubview(HorizontalBorder());
            vsv1.AddArrangedSubview(hsv2);
            vsv1.AddArrangedSubview(HorizontalBorder());
            vsv1.AddArrangedSubview(hsv3);
            vsv1.AddArrangedSubview(HorizontalBorder());
            cell.ContentView.AddSubview(vsv1);

            int i = 0;
            foreach (int value in list[indexPath.Row])
            {
                UIView tx;
                if (value > 0)
                {
                    tx = new UILabel();
                    (tx as UILabel).Text = value.ToString();
                    (tx as UILabel).TextAlignment = UITextAlignment.Center;
                    (tx as UILabel).AdjustsFontSizeToFitWidth = true;
                    //(tx as UILabel).Font = (tx as UITextView).Font.WithSize(19f);
                }
                else
                {
                    tx = new UITextField();
                    (tx as UITextField).TextAlignment = UITextAlignment.Center;
                    (tx as UITextField).KeyboardType = UIKeyboardType.DecimalPad;
                    (tx as UITextField).ShouldChangeCharacters = (textField, range, replacementString) => {
                        var newLength = textField.Text.Length + replacementString.Length - range.Length;
                        return newLength <= 1;
                    };
                    int col = i;
                    int row = 0;
                    while (col > 2)
                    {
                        row += 1;
                        col -= 3;
                    }
                    (tx as UITextField).EditingChanged += (s, e) =>
                    {                        
                        int digit = int.Parse((s as UITextField).Text.ToString());
                        int[,] dimension = new int[row, col];
                        listener.OnAnswer(indexPath.Row, row, col, digit);
                    };
                }
                switch (i++)
                {
                    case 0:
                    case 1:
                    case 2:
                        AddArrangedSubCell(hsv1, tx, rowWidth / 3, rowHeight);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        AddArrangedSubCell(hsv2, tx, rowWidth / 3, rowHeight);
                        break;
                    case 6:
                    case 7:
                    case 8:
                        AddArrangedSubCell(hsv3, tx, rowWidth / 3, rowHeight);
                        break;
                    default:
                        break;
                }
            }
            return cell;
        }

        private UIStackView HorizontalStackView(nfloat w, nfloat h)
        {
            UIStackView view = new UIStackView();
            view.Axis = UILayoutConstraintAxis.Horizontal;
            view.Distribution = UIStackViewDistribution.EqualSpacing;
            view.WidthAnchor.ConstraintEqualTo(w).Active = true;
            view.HeightAnchor.ConstraintEqualTo(h).Active = true;
            return view;
        }

        private void AddArrangedSubCell(UIStackView sv, UIView tx, nfloat w, nfloat h)
        {
            tx.WidthAnchor.ConstraintEqualTo(w - 4).Active = true;
            tx.HeightAnchor.ConstraintEqualTo(h).Active = true;
            sv.AddArrangedSubview(VerticalBorder());
            sv.AddArrangedSubview(tx);
            sv.AddArrangedSubview(VerticalBorder());
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
            nfloat size = ((screenRect.Size.Width - 80f) / 3);
            return new CoreGraphics.CGSize(width: size, height: size);
        }
    }
}
