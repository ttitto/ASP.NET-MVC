namespace Ttitter.Data.Data
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;

    using Ttitter.Data.Data.Repositories;
    using Ttitter.Data.Models;

    public interface ITtitterData
    {
        ITtitterRepository<Profile> Profiles { get; }

        ITtitterRepository<Tteet> Tteets { get; }

        ITtitterRepository<Message> Messages { get; }

        ITtitterRepository<Notification> Notifications { get; }

        ITtitterRepository<Image> Images { get; }

        ITtitterRepository<User> Users { get; }

        IEnumerable<DbEntityValidationResult> GetValidationErrors();

        int SaveChanges();
    }
}
