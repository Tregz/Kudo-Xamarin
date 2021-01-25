using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Kudo.Droid
{
    public class GameAdapter : BaseAdapter
    {
        readonly List<int> list = new List<int>();
        readonly Context context;

        public GameAdapter(Context context, List<int[,]> list)
        {
            this.context = context;
            foreach (int[,] i in list)
                foreach (int j in i)
                    this.list.Add(j);
        }

        public override int Count => list.Count;

        public override Java.Lang.Object GetItem(int position) => null;

        public override long GetItemId(int position) => 0;

        public override View GetView(int position, View cell, ViewGroup parent)
        {
            RelativeLayout rl;
            TextView tv = null;
            EditText et = null;
            int value = list[position];
            int size = parent.Width / 9;
            if (cell == null)
            {
                rl = new RelativeLayout(context); /*
                {
                    Gravity = GravityFlags.Center
                    //Orientation = Orientation.Vertical,
                    //TextAlignment = TextAlignment.Center,
                };*/

                // TODO
                rl.SetGravity(GravityFlags.Center);

                if (value > 0)
                {
                    tv = new TextView(context)
                    {
                        TextAlignment = TextAlignment.Center,
                    };
                    //tv.SetPadding(8, 8, 8, 8);

                    // TODO
                    tv.SetMinimumHeight(size);
                    tv.SetMinimumWidth(size);

                    // TODO tv.SetAutoSizeTextTypeWithDefaults(AutoSizeTextType.Uniform);
                    rl.AddView(tv);
                }
                else
                {
                    et = new EditText(context)
                    {
                        TextAlignment = TextAlignment.Center
                    };
                    //et.SetPadding(8, 8, 8, 8);
                    rl.AddView(et);
                }
            }
            else
            {
                rl = (RelativeLayout)cell;
                if (rl.ChildCount > 0)
                {
                    if (value > 0)
                        tv = (TextView)rl.GetChildAt(0);
                    else if (value == -1)
                        et = (EditText)rl.GetChildAt(0);
                }
            }

            if (value > 0 && tv != null)
            {
                tv.Text = value.ToString();
            }
            else if (value == -1 && et != null)
            {
                et.Text = value.ToString();
            }

            // TODO
            //rl.SetMinimumHeight(size);
            //rl.SetMinimumWidth(size);

            return rl;
        }
    }
}
