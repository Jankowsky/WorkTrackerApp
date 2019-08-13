using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using WorkTrackerApp.Models;
using WorkTrackerApp.Views;
using Xamarin.Forms;

namespace WorkTrackerApp.ViewModels
{


    public class CompanyDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public int SelectedYear { get; set; }
        public List<int> Years { get; set; }
        public Chart Chart { get; private set; }
        public Command LoadCompanyCommand { get; set; }
        public int[] workedTime = new int[12];
        public int sumWorkedTime = 0;
        public ObservableCollection<Microcharts.Entry> entries { get; set; }



        public CompanyDetailViewModel(Item item = null)
        {
            Years = new List<int>();
            Years.Add(DateTime.Now.Year);
            SelectedYear = Years[0];
            Item = item;
            entries = new ObservableCollection<Microcharts.Entry>();
            LoadCompanyCommand = new Command(async () => await ExecuteLoadCompanyCommand());
            LoadCompanyCommand.Execute(null);
            Title = item?.Company;

            Chart = new BarChart { Entries = entries, LabelTextSize = 20};


            MessagingCenter.Subscribe<CompanyDetailPage>(this, "ChangeYear", async (obj) =>
            {
                // not working need to refresh chart
                LoadCompanyCommand.Execute(null);

            });
        }



        async Task ExecuteLoadCompanyCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                var raports = await DataStore.GetCompanyAsync(Item.Company, true);
                foreach (var raport in raports)
                {
                    if (raport.Date.Year == SelectedYear)
                    {
                        sumWorkedTime += raport.WorkedTime;
                        workedTime[raport.Date.Month - 1] += raport.WorkedTime;
                    }
                }
                int i = 0;
                entries.Clear();
                foreach (var val in workedTime)
                {

                    i++;

                    var random = new Random();
                    var color = String.Format("#{0:X6}", random.Next(0x1000000)); // = "#A197B9"
                    TimeSpan ts = new TimeSpan((val / 60), (val % 60), 0);

                    entries.Add(new Microcharts.Entry(val)
                    {
                        Label = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i),
                        ValueLabel = String.Format("{0:%h} hours {0:%m} minutes", ts),
                        Color = SKColor.Parse(color)
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
