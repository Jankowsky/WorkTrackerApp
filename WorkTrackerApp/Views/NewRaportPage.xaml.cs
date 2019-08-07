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

        public NewRaportPage()
        {
            InitializeComponent();

            Item = new Raport
            {
                Company = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
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
