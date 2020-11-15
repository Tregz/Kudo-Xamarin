using System;

using Android.Views;
using Android.Support.V7.Widget;

namespace Kudo.Droid
{
    public class ListRecycler : RecyclerView.Adapter
    {
        public event EventHandler<ListEvent> ItemClick;
        public event EventHandler<ListEvent> ItemLongClick;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }

        public override int ItemCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected void OnClick(ListEvent args) => ItemClick?.Invoke(this, args);
        protected void OnLongClick(ListEvent args) => ItemLongClick?.Invoke(this, args);
    }
}
