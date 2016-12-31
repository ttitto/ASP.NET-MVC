namespace PerformanceSurf.Hubs
{
    using System.Threading.Tasks;
    using Counters;
    using Microsoft.AspNet.SignalR;

    public class PerfHub : Hub
    {
        public PerfHub()
        {
            this.StartCounterCollection();
        }

        public void Send(string message)
        {
            Clients.All.newMessage(Context.User.Identity.Name + " says:\n\t" + message);
        }

        private void StartCounterCollection()
        {
            var task = Task.Factory.StartNew(async () => {
                var perfService = new PerfCounterService();
                while (true)
                {
                    var results = perfService.GetResults();
                    Clients.All.newCounters(results);
                    await Task.Delay(2000);
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
}