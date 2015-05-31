namespace Ttitter.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message: BaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ReceiverProfile")]
        public int ReceiverProfileId { get; set; }

        [InverseProperty("ReceivedMessages")]
        public virtual Profile ReceiverProfile { get; set; }

        [Required]
        [ForeignKey("SenderProfile")]
        public int SenderProfileId { get; set; }

        [InverseProperty("SentMessages")]
        public virtual Profile SenderProfile { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        protected override System.Collections.Generic.IEnumerable<ValidationResult> ValidateModel(ValidationContext validationContext)
        {
            return base.ValidateModel(validationContext);
        }
    }
}
