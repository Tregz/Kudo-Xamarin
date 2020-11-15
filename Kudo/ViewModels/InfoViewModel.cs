using System.Windows.Input;

namespace Kudo
{
    public class InfoViewModel : BaseViewModel
    {
        public InfoViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Plugin.Share.CrossShare.Current.OpenBrowser("https://xamarin.com/platform"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
