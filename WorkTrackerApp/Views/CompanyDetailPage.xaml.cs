﻿using System;
using System.Collections.Generic;
using WorkTrackerApp.Models;
using WorkTrackerApp.ViewModels;

using Xamarin.Forms;

namespace WorkTrackerApp.Views
{
    public partial class CompanyDetailPage : ContentPage
    {
        CompanyDetailViewModel viewModel;

        public CompanyDetailPage(CompanyDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CompanyDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Id = 0,
                Company = "Company name",
                WorkedSum = 0,
                WorkedTimeText = ""
            };
            
            viewModel = new CompanyDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
