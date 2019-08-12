using System;

namespace WorkTrackerApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public int WorkedSum { get; set; }
        public string WorkedTimeText { get; set; }
    }
}