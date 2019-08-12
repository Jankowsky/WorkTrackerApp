using System;
using System.ComponentModel;
using WorkTrackerApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkTrackerApp.Views
{
    
    [DesignTimeVisible(false)]
    public partial class RaportSummaryPage : ContentPage
    {
        RaportSummaryViewModel viewModel;

        public RaportSummaryPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RaportSummaryViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}