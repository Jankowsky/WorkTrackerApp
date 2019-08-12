using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTrackerApp.Models;
using System.Linq;

namespace WorkTrackerApp.Services
{
    public class SQLiteDataStore : IDataStore<Raport>
    {
        List<Raport> raports;
      
        
        public SQLiteDataStore()
        {
            raports = new List<Raport>();

            LoadData().Wait(50);
        }

        public async Task LoadData()
        {
            raports = await App.Database.GetItemsAsync();
           
        }

        public async Task<bool> AddItemAsync(Raport item)
        {
            await App.Database.SaveItemAsync(item);
            await LoadData();

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Raport item)
        {
            var oldItem = raports.Where((Raport arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(oldItem);
            //items.Add(item);
            await App.Database.DeleteItemAsync(oldItem);
            await App.Database.SaveItemAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = raports.Where((Raport arg) => arg.Id == id).FirstOrDefault();
            //items.Remove(oldItem);
            await App.Database.DeleteItemAsync(oldItem);
            await LoadData();
            return await Task.FromResult(true);
        }

        public async Task<Raport> GetItemAsync(int id)
        {
            //return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
            return await await Task.FromResult(App.Database.GetItemAsync(id));
        }

        public async Task<IEnumerable<Raport>> GetItemsAsync(bool forceRefresh = false)
        {
            await LoadData();
            return await Task.FromResult(raports);
        }

       
    }
}
