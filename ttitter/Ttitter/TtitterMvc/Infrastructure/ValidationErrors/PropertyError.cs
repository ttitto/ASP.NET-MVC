namespace TtitterMvc.Infrastructure.ValidationErrors
{
    using System;

    public class PropertyError : Exception, IBaseError
    {
        private string propertyName;
        private string propertyExceptionMessage;

        public PropertyError(string propertyName, string propertyExceptionMessage)
        {
            this.propertyName = propertyName;
            this.propertyExceptionMessage = propertyExceptionMessage;
        }

        public string PropertyName
        {
            get { return this.propertyName; }
        }

        public string PropertyExceptionMessage
        {
            get { return this.propertyExceptionMessage; }
        }
    }
}