namespace KatanaIntro
{
    using System.Web.Http;

    public class GreetingController : ApiController
    {
        public Greeting Get()
        {
            return new Greeting { Text = "Hello World!!" };
        }
    }
}
