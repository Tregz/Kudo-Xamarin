using System;

namespace Kudo
{
    public class SoloViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public SoloViewModel(Item item = null)
        {
            if (item != null)
            {
                Title = item.Text;
                Item = item;
            }
        }
    }
}
