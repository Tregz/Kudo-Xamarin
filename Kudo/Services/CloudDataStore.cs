using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Kudo
{
    public class CloudDataStore : IDataStore<Game>
    {
        readonly HttpClient client;
        IEnumerable<Game> items;

        public CloudDataStore()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.BackendUrl}/")
            };

            items = new List<Game>();
        }

        public async Task<IEnumerable<Game>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"game");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Game>>(json));
            }

            return items;
        }

        public async Task<Game> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"game/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Game>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Game item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"game", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Game item)
        {
            if (item == null || item.Guid == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"game/{item.Guid}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"game/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
