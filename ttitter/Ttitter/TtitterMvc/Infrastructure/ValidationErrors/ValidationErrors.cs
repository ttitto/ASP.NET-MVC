namespace TtitterMvc.Infrastructure.ValidationErrors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ValidationErrors : Exception, IValidationErrors
    {
        public ValidationErrors()
        {
            this.Errors = new List<IBaseError>();
        }

        public ValidationErrors(IBaseError error)
            : this()
        {
            this.Errors.Add(error);
        }

        public ICollection<IBaseError> Errors
        {
            get;
            set;
        }
    }
}