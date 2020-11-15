using System;
using Android.Views;

namespace Kudo.Droid
{
    public class ListEvent : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}
