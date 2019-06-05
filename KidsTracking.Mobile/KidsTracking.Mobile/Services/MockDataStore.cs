using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidsTracking.Mobile.Models;

namespace KidsTracking.Mobile.Services
{
    public class MockDataStore : IDataStore<Kid>
    {
        List<Kid> items;

        public MockDataStore()
        {
            items = new List<Kid>();
            var mockItems = new List<Kid>
            {
                //new Kid { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //new Kid { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new Kid { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new Kid { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new Kid { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new Kid { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Kid item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Kid item)
        {
            var oldItem = items.Where((Kid arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Kid arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Kid> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Kid>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}