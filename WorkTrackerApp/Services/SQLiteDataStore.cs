using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTrackerApp.Models;

namespace WorkTrackerApp.Services
{
    public class SQLiteDataStore : IDataStore<Raport>
    {
        public SQLiteDataStore()
        {
        }

        public Task<bool> AddItemAsync(Raport item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Raport> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Raport>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Raport item)
        {
            throw new NotImplementedException();
        }
    }
}
