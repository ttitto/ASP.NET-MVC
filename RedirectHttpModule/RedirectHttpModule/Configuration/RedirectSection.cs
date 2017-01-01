namespace RedirectHttpModule.Configuration
{
    using System.Configuration;

    public class RedirectSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(RedirectCollection))]
        public RedirectCollection Redirects
        {
            get
            {
                return (RedirectCollection)base[string.Empty];
            }
        }
    }
}