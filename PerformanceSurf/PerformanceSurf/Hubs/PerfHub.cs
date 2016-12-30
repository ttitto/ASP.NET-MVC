namespace PerformanceSurf.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class PerfHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.newMessage(Context.User.Identity.Name + " says:\n\t" + message);
        }
    }
}