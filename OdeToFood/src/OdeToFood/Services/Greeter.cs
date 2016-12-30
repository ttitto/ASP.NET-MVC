using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public class Greeter : IGreeter
    {
        private string greeting;

        public Greeter(IConfiguration configuration)
        {
            this.greeting = configuration["greeting"];
        }

        public string GetGreeting()
        {
            return this.greeting;
        }
    }
}
