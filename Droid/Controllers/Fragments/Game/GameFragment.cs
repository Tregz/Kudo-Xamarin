using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Kudo.Droid
{
    public class GameFragment : AndroidX.Fragment.App.Fragment, BaseFragment
    {
        public static GameFragment NewInstance() =>
            new GameFragment { Arguments = new Bundle() };


        public GameViewModel ViewModel { get; set; }

        public List<int[,]> Soluce { get; set; }
        public List<int[,]> Answers { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ViewModel = new GameViewModel();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_game, container, false);
            return view;
        }

        public override void OnStart()
        {
            base.OnStart();
            Soluce = ViewModel.Sudoku;
            Answers = new List<int[,]>();
            for (int i = 0; i < 9; i++) Answers.Add(new int[3, 3]);
            GridView grid = View.FindViewById<GridView>(Resource.Id.grid);
            grid.Adapter = new GameAdapter(Context, ViewModel.Puzzle);

        }

        public void BecameVisible()
        {
            // Set height to aspect ratio 1:1
            GridView grid = View.FindViewById<GridView>(Resource.Id.grid);
            ViewGroup.LayoutParams lp = grid.LayoutParameters;
            lp.Height = grid.MeasuredWidth;
            grid.LayoutParameters = lp;
        }
    }
}
