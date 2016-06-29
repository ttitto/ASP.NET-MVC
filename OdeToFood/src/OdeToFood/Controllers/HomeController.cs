namespace OdeToFood.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from Controller index action.";
        }
    }
}
