namespace TtitterMvc.Infrastructure.ValidationErrors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public static class ControllersExtensions
    {
        public static void AddValidationErrors(this ModelStateDictionary modelState, IValidationErrors propertyErrors)
        {
            foreach (var databaseValidationError in propertyErrors.Errors)
            {
                modelState.AddModelError(databaseValidationError.PropertyName, databaseValidationError.PropertyExceptionMessage);
            }
        }
    }
}