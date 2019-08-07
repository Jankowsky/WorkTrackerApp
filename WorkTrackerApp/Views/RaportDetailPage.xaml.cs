using System;
using System.Collections.Generic;
using WorkTrackerApp.Models;
using WorkTrackerApp.ViewModels;
using Xamarin.Forms;

namespace WorkTrackerApp.Views
{
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
    }
}
