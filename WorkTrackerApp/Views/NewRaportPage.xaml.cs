using System;
using System.Collections.Generic;
using System.ComponentModel;
using WorkTrackerApp.Models;
using Xamarin.Forms;

namespace WorkTrackerApp.Views
{
    [DesignTimeVisible(false)]
    public partial class NewRaportPage : ContentPage
    {
        public Raport Item { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
        public NewRaportPage()
        {
            InitializeComponent();

            StartTime = TimeSpan.Zero;
            EndTime = TimeSpan.Zero;
            Date = DateTime.Now;

            Item = new Raport
            {
                Company = "Comapny name",
                Date = DateTime.Now,
                WorkedTime = 0,
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        void Time_Changed(object sender, EventArgs e)
        {
            if(TimeSpan.Compare(StartTime,EndTime) < 0)
            {
                Item.WorkedTime = (EndTime.Hours*60 + EndTime.Minutes) - (StartTime.Hours*60 + StartTime.Minutes);
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
