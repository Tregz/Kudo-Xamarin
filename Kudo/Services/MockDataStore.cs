using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Kudo
{
    public class MockDataStore : IDataStore<Game>
    {
        List<Game> items;

        public MockDataStore()
        {
            items = new List<Game>();
            String id = Guid.NewGuid().ToString();
            Preferences.Set("game", id);
            var _items = new List<Game>
            {
                new Game { Id = id, Text = "Save", Description="Game settings and score", Level=0, Successes=0},
            };

            foreach (Game item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Game item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Game item)
        {
            var _item = items.Where((Game arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Game arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Game> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Game>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
