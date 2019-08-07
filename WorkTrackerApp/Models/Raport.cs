using System;
namespace WorkTrackerApp.Models
{
    public class Raport
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public DateTime Date { get; set; }
        public int WorkedTime { get; set; }
        public string Description { get; set; }
    }
}
