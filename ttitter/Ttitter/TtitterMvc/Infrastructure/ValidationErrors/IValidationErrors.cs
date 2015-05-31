namespace TtitterMvc.Infrastructure.ValidationErrors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IValidationErrors
    {
        ICollection<IBaseError> Errors { get; set; }
    }
}
