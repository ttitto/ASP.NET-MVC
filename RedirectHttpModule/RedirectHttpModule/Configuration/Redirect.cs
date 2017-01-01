namespace RedirectHttpModule.Configuration
{
    using System.Configuration;

    public class Redirect : ConfigurationElement
    {
        private const string OldUrl = "Old";
        private const string NewUrl = "New";
        private const string TitleUrl = "Title";

        [ConfigurationProperty(OldUrl)]
        public string Old
        {
            get
            {
                return (string)this[OldUrl];
            }
            set
            {
                this[OldUrl] = value;
            }
        }

        [ConfigurationProperty(NewUrl)]
        public string New
        {
            get
            {
                return (string)this[NewUrl];
            }
            set
            {
                this[NewUrl] = value;
            }
        }

        [ConfigurationProperty(TitleUrl)]
        public string Title
        {
            get
            {
                return (string)this[TitleUrl];
            }
            set
            {
                this[TitleUrl] = value;
            }
        }
    }
}