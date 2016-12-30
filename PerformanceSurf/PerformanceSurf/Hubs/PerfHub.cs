namespace PerformanceSurf.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class PerfHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}