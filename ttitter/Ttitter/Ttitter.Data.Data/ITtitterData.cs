namespace Ttitter.Data.Data
{
    using Ttitter.Data.Data.Repositories;
    using Ttitter.Data.Models;

    public interface ITtitterData
    {
        ITtitterRepository<Profile> Profiles { get; }

        ITtitterRepository<Tteet> Tteets { get; }

        ITtitterRepository<Message> Messages { get; }

        ITtitterRepository<Notification> Notifications { get; }

        int SaveChanges();
    }
}
