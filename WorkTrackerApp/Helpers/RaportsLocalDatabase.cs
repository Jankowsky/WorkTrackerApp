using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using WorkTrackerApp.Models;

namespace WorkTrackerApp.Helpers
{
    public class RaportsLocalDatabase
    {
        private SQLiteAsyncConnection database;
        

        public RaportsLocalDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Raport>().Wait();
        }

        public Task<List<Raport>> GetItemsAsync()
        {
            return database.Table<Raport>().ToListAsync();
        }

        public Task<List<Raport>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Raport>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Raport> GetItemAsync(int id)
        {
            return database.Table<Raport>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Raport item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Raport item)
        {
            return database.DeleteAsync(item);
        }
    }
}
