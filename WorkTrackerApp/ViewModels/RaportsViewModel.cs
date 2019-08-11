﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WorkTrackerApp.Models;
using WorkTrackerApp.Views;
using Xamarin.Forms;

namespace WorkTrackerApp.ViewModels
{
    public class RaportsViewModel : BaseViewModel
    {
        public ObservableCollection<Raport> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public RaportsViewModel()
        {
            Title = "Raports";
            Items = new ObservableCollection<Raport>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewRaportPage, Raport>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Raport;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<RaportDetailPage, Raport>(this, "DeleteItem", async (obj, _item) =>
            {
                var oldItem = _item as Raport;
                Items.Remove(_item);
                await DataStore.DeleteItemAsync(oldItem.Id);
            });
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


    }
}
