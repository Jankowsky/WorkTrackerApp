using System;
using SQLite;

namespace WorkTrackerApp.Models
{
    public class Raport
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime Date { get; set; }
        public int WorkedTime { get; set; }
        public string Description { get; set; }
    }
}
