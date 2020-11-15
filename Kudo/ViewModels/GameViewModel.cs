using System;

namespace Kudo
{
    public class GameViewModel : BaseViewModel
    {
        bool isTrue = false;
        public bool IsTrue
        {
            get { return isTrue; }
            set { SetProperty(ref isTrue, value); }
        }

        public GameViewModel()
        {
            Title = "Game";   
        }
    }
}
