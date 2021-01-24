using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Kudo
{
    public class ListViewModel : BaseViewModel
    {
        public ObservableCollection<Game> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }

        public ListViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Game>();
            LoadItemsCommand = new Command(async () =>
            await ExecuteLoadItemsCommand());
            AddItemCommand = new Command<Game>(async (Game item) =>
            await AddItem(item));
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task AddItem(Game item)
        {
            Items.Add(item);
            await DataStore.AddItemAsync(item);
            await Cloud.AddItemAsync(item);
        }
    }
}
