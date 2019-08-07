using System;

using Xamarin.Forms;

namespace WorkTrackerApp.Views
{
    public partial class RaportsPage : ContentPage
    {
        public RaportsPage()
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

