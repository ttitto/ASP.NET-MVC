namespace GigHub.ViewModels
{
    using System.Collections.Generic;
    using Models;

    public class HomeViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Gig> UpcommingGigs { get; set; }
    }
}