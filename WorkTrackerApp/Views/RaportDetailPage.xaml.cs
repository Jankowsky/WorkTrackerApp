using System;
using System.Collections.Generic;
using System.ComponentModel;
using WorkTrackerApp.Models;
using WorkTrackerApp.ViewModels;
using Xamarin.Forms;

namespace WorkTrackerApp.Views
{
    [DesignTimeVisible(false)]
    public partial class RaportDetailPage : ContentPage
    {

        RaportDetailViewModel viewModel;


        public RaportDetailPage(RaportDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        public RaportDetailPage()
        {
            InitializeComponent();

            var item = new Raport
            {
                Company = "Item 1",
                Date = DateTime.Today,
                WorkedTime = 210,
                Description = "This is an item description."
            };

            viewModel = new RaportDetailViewModel(item);
            BindingContext = viewModel;
        }

        
        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteItem", viewModel.Item as Raport);
            await Navigation.PopModalAsync();
        }
    }
}
