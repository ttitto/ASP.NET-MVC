namespace Ttitter.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ReceiverProfile")]
        public Guid ReceiverProfileId { get; set; }

        [InverseProperty("ReceivedMessages")]
        public virtual Profile ReceiverProfile { get; set; }

        [Required]
        [ForeignKey("SenderProfile")]
        public Guid SenderProfileId { get; set; }

        [InverseProperty("SentMessages")]
        public virtual Profile SenderProfile { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }
    }
}
