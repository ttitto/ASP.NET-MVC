namespace OdeToFood.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("company/[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+359 555 22 33 44";
        }

        [Route("[action]")]
        public string Country()
        {
            return "Bulgaria";
        }
    }
}
