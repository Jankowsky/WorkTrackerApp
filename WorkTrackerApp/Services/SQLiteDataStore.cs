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
            var mockItems = new List<Raport>
            {
                new Raport { Id = Guid.NewGuid().ToString(), Company = "First company", Date = DateTime.Today, WorkedTime = 100, Description="This is an item description." },
                new Raport { Id = Guid.NewGuid().ToString(), Company = "Second company", Date = DateTime.Today, WorkedTime = 200, Description="This is an item description." },
                new Raport { Id = Guid.NewGuid().ToString(), Company = "Third company", Date = DateTime.Today, WorkedTime = 60, Description="This is an item description." },
                new Raport { Id = Guid.NewGuid().ToString(), Company = "First item", Date = DateTime.Today, WorkedTime = 600, Description="This is an item description." },
                new Raport { Id = Guid.NewGuid().ToString(), Company = "Second item", Date = DateTime.Today, WorkedTime = 520, Description="This is an item description." },
                new Raport { Id = Guid.NewGuid().ToString(), Company = "Third item", Date = DateTime.Today, WorkedTime = 330, Description="This is an item description." }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Raport item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Raport item)
        {
            var oldItem = items.Where((Raport arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Raport arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Raport> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Raport>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
