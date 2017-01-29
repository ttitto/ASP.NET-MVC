namespace GigHub.ViewModels
{
    using System;
    using System.Collections.Generic;
    using GigHub.Models;

    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime DateTime
        {
            get
            {
                return DateTime.Parse($"{this.Date} {this.Time}");
            }
        }
    }
}