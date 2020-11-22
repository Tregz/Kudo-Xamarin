using System;

namespace Kudo
{
    public class SoloViewModel : BaseViewModel
    {
        public Game Item { get; set; }
        public SoloViewModel(Game item = null)
        {
            if (item != null)
            {
                Title = item.Text;
                Item = item;
            }
        }
    }
}
