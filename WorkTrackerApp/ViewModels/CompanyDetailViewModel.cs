using System;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;
using WorkTrackerApp.Models;

namespace WorkTrackerApp.ViewModels
{
    public class CompanyDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public int SelectedYear { get; set; }
        public List<int> Years { get; set; }
        public Chart Chart { get; private set; }

        public List<Entry> entries = new List<Entry>
        {
            new Entry(200)
            {
                Color=SKColor.Parse("#FF1943"),
                Label ="January",
                ValueLabel = "200"
            },
            new Entry(400)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "March",
                ValueLabel = "400"
            },
            new Entry(-100)
            {
                Color =  SKColor.Parse("#00CED1"),
                Label = "Octobar",
                ValueLabel = "-100"
            },
        };

        public CompanyDetailViewModel(Item item = null)
        {
            Years = new List<int>();
            Years.Add(DateTime.Now.Year);
            SelectedYear = Years[0];
            Title = item?.Company;
            Item = item;
            Chart = new BarChart { Entries = entries }; 
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
