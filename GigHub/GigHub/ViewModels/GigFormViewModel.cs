namespace GigHub.ViewModels
{
    using System.Collections.Generic;
    using GigHub.Models;

    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}