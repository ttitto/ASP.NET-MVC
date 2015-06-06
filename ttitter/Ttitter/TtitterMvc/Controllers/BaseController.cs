namespace TtitterMvc.Controllers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using TtitterMvc.Infrastructure.Services.Contracts;

    public abstract class BaseController : Controller
    {
        IBaseService baseService;

        public BaseController(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        protected virtual void ApplyErrorsToModelState(object model, Controller controller)
        {
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            // DataAnnotation validation
            Validator.TryValidateObject(model, validationContext, validationResults, true);


            // IValidatableObject validation
            var validatable = model as IValidatableObject;
            if (null != validatable)
            {
                var errors = validatable.Validate(new ValidationContext(controller));
                validationResults.Concat(errors);

            }

            foreach (var validationResult in validationResults)
            {
                foreach (var memberName in validationResult.MemberNames)
                {
                   ModelState.AddModelError(memberName, validationResult.ErrorMessage);
                }
            }
        }
    }
}