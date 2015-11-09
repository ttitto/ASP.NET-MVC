namespace MvcUoWAutomNin.Data
{
    using Models;
    using Repositories;

    public interface IMvcUoWAutomNinData
    {
        IMvcUoWAutomNinRepository<User> Users { get; }

        // TODO: Add here more repositories


        int SaveChanges();
    }
}
