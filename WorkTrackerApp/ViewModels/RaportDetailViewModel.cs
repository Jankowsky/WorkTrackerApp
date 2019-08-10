using System;
using WorkTrackerApp.Models;

namespace WorkTrackerApp.ViewModels
{
    public class RaportDetailViewModel : BaseViewModel
    {
        public Raport Item { get; set; }
        public string WorkedTime { get; set; }
        public string Date { get; set; }
        public RaportDetailViewModel(Raport item = null)
        {
            Title = item?.Company;
            Item = item;
            WorkedTime = CalculateWorkTime(item.WorkedTime);
            Date = item.Date.ToShortDateString();
        }

        private String CalculateWorkTime(int workedTime)
        {
            TimeSpan ts = new TimeSpan((workedTime/60),(workedTime%60), 0);
            return String.Format("{0:%h} hours {0:%m} minutes", ts);
        }
    }
}
