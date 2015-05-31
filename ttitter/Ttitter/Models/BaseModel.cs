namespace Ttitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseModel : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return this.ValidateModel(validationContext);
        }

        protected virtual IEnumerable<ValidationResult> ValidateModel(ValidationContext validationContext)
        {
            return new Collection<ValidationResult>();
        }
    }
}
