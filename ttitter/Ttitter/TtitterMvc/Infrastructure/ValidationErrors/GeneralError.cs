namespace TtitterMvc.Infrastructure.ValidationErrors
{
    using System;

    public class GeneralError : Exception, IBaseError
    {
        private string propertyExceptionMessage;

        public GeneralError(string errorMessage)
        {
            this.propertyExceptionMessage = errorMessage;
        }

        public string PropertyName
        {
            get { return string.Empty; }
        }

        public string PropertyExceptionMessage
        {
            get { return this.propertyExceptionMessage; }
        }
    }
}