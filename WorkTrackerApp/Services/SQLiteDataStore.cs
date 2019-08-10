using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTrackerApp.Models;
using System.Linq;

namespace WorkTrackerApp.Services
{
    public class SQLiteDataStore : IDataStore<Raport>
    {
        List<Raport> items;
        
        public SQLiteDataStore()
        {
            items = new List<Raport>();

            LoadData();
        }

        public async void LoadData()
        {
            items = await App.Database.GetItemsAsync();
        }

        public async Task<bool> AddItemAsync(Raport item)
        {
            await App.Database.SaveItemAsync(item);
            LoadData();

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Raport item)
        {
            var oldItem = items.Where((Raport arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(oldItem);
            //items.Add(item);
            await App.Database.DeleteItemAsync(oldItem);
            await App.Database.SaveItemAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Raport arg) => arg.Id == id).FirstOrDefault();
            //items.Remove(oldItem);
            await App.Database.DeleteItemAsync(oldItem);
            LoadData();
            return await Task.FromResult(true);
        }

        public async Task<Raport> GetItemAsync(int id)
        {
            //return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
            return await await Task.FromResult(App.Database.GetItemAsync(id));
        }

        public async Task<IEnumerable<Raport>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
