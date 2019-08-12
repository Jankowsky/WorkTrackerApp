using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WorkTrackerApp.Models;
using Xamarin.Forms;

namespace WorkTrackerApp.ViewModels
{
    public class RaportSummaryViewModel : BaseViewModel
    {
        
        public ObservableCollection<Item> Items {get;set;}
    
        public Command LoadItemsCommand { get; set; }

        public RaportSummaryViewModel()
        {
            Title = "Summary";

            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
                if (IsBusy)
                    return;

                IsBusy = true;

                try
                {
                    Items.Clear();
                    var Raports = await DataStore.GetItemsAsync(true);
                    var i = 0;
                    var companys = Raports.Select(o => new { o.Company }).Distinct();
                    foreach (var company in companys)
                    {
                    var sum = Raports.Where(o => o.Company == company.Company).Select(s => s.WorkedTime).Sum();
                    var ts = new TimeSpan((sum / 60), (sum % 60), 0);
                    var sumText = String.Format("Totally worked: {0:%h} hours {0:%m} minutes.", ts);
                    Items.Add(new Item
                    {
                        Id = i,
                        Company = company.Company,
                        WorkedSum = sum,
                        WorkedTimeText = sumText
                    });
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
