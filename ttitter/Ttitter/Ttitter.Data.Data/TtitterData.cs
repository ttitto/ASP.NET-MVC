﻿namespace Ttitter.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Ttitter.Data.Data.Repositories;
    using Ttitter.Data.Models;

    public class TtitterData : ITtitterData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public TtitterData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public ITtitterRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public ITtitterRepository<Profile> Profiles
        {
            get { return this.GetRepository<Profile>(); }
        }

        public ITtitterRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public ITtitterRepository<Message> Messages
        {
            get { return this.GetRepository<Message>(); }
        }

        public ITtitterRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private ITtitterRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfTttitterRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (ITtitterRepository<T>)repositories[typeOfRepository];
        }
    }
}
