namespace Ttitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Notification : BaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        [Required]
        public NotificationCase NotificationCase { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        public DateTime ViewedOn { get; set; }

        protected override IEnumerable<ValidationResult> ValidateModel(ValidationContext validationContext)
        {
            var baseCollection = base.ValidateModel(validationContext);
            foreach (var item in baseCollection)
            {
                yield return item;
            }

            if (this.ViewedOn <= this.SentOn)
            {
                yield return new ValidationResult("The Notification can not be viewed before it has been sent.", new[] { "ViewedOn, SentOn" });
            }
        }
    }
}
