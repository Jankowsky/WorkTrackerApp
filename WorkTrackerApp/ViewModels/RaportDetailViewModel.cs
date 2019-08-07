using System;
using WorkTrackerApp.Models;

namespace WorkTrackerApp.ViewModels
{
    public class RaportDetailViewModel : BaseViewModel
    {
        public Raport Item { get; set; }
        public RaportDetailViewModel(Raport item = null)
        {
            Title = item?.Company;
            Item = item;
        }
    }
}
