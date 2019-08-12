using System;
using System.Collections.Generic;
using WorkTrackerApp.Models;

namespace WorkTrackerApp.ViewModels
{
    public class CompanyDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public int SelectedYear { get; set; }
        public List<int> Years { get; set; }

        public CompanyDetailViewModel(Item item = null)
        {
            Years = new List<int>();
            Years.Add(DateTime.Now.Year);
            SelectedYear = Years[0];
            Title = item?.Company;
            Item = item;
        }

        public string DisplayPicker
        {
            get
            {
                return SelectedYear.ToString();
            }
        }

    }
}
