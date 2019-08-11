using System;
using System.Collections.Generic;
using System.ComponentModel;
using WorkTrackerApp.Models;
using WorkTrackerApp.ViewModels;
using Xamarin.Forms;

namespace WorkTrackerApp.Views
{
    [DesignTimeVisible(false)]
    public partial class RaportsPage : ContentPage
    {
        RaportsViewModel viewModel;

        public RaportsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RaportsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Raport;
            if (item == null)
                return;

            await Navigation.PushModalAsync(new NavigationPage(new RaportDetailPage(new RaportDetailViewModel(item))));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewRaportPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
