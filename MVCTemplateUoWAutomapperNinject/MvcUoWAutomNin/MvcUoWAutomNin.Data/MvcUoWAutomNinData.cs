namespace MvcUoWAutomNin.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Repositories;
    using Models;

    public class MvcUoWAutomNinData : IMvcUoWAutomNinData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public MvcUoWAutomNinData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IMvcUoWAutomNinRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IMvcUoWAutomNinRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(MvcUoWAutomNinEfRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IMvcUoWAutomNinRepository<T>)repositories[typeOfRepository];
        }
    }
}
