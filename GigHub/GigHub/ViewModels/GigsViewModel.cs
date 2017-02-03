namespace GigHub.ViewModels
{
    using System.Collections.Generic;
    using Models;

    public class GigsViewModel
    {
        public string Heading { get; set; }
        public bool ShowActions { get; set; }
        public IEnumerable<Gig> UpcommingGigs { get; set; }
    }
}