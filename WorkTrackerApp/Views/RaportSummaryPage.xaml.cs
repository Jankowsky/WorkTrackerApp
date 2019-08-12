using System;
using System.ComponentModel;
using WorkTrackerApp.Models;
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

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushModalAsync(new NavigationPage(new CompanyDetailPage(new CompanyDetailViewModel(item))));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}