using System.Windows.Input;
using Plugin.Share;

namespace Kudo
{
    public class InfoViewModel : BaseViewModel
    {
        public InfoViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() =>
            CrossShare.Current.OpenBrowser("https://xamarin.com/platform"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
