using System;

using Xamarin.Forms;

namespace WorkTrackerApp.Views
{
    public class RaportDetailPage : ContentPage
    {
        public RaportDetailPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

