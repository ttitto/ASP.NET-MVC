namespace Ttitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tteet : BaseModel
    {
        ICollection<Profile> retteetingProfiles;
        ICollection<Profile> favourizingProfiles;
        ICollection<Profile> reportingProfiles;
        ICollection<Profile> fbSharingProfiles;
        ICollection<Tteet> tteetReplies;

        public Tteet()
        {
            this.retteetingProfiles = new HashSet<Profile>();
            this.favourizingProfiles = new HashSet<Profile>();
            this.reportingProfiles = new HashSet<Profile>();
            this.fbSharingProfiles = new HashSet<Profile>();
            this.tteetReplies = new HashSet<Tteet>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public int? RepliesToId { get; set; }

        [ForeignKey("RepliesToId")]
        public virtual Tteet RepliesTo { get; set; }

        public int? ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }

        [Column("RetteetingProfiles")]
        [InverseProperty("RetteetedTteets")]
        public virtual ICollection<Profile> RetteetingProfiles
        {
            get { return this.retteetingProfiles; }
            set { this.retteetingProfiles = value; }
        }

        [Column("FavourizingProfiles")]
        [InverseProperty("FavouriteTteets")]
        public virtual ICollection<Profile> FavourizingProfiles
        {
            get { return this.favourizingProfiles; }
            set { this.favourizingProfiles = value; }
        }

        [Column("ReportingProfiles")]
        [InverseProperty("ReportedTteets")]
        public virtual ICollection<Profile> ReportingProfiles
        {
            get { return this.reportingProfiles; }
            set { this.reportingProfiles = value; }
        }

        [Column("FbSharingProfiles")]
        [InverseProperty("FbSharedTteets")]
        public virtual ICollection<Profile> FbSharingProfiles
        {
            get { return this.fbSharingProfiles; }
            set { this.fbSharingProfiles = value; }
        }

        [Column("TteetReplies")]
        public virtual ICollection<Tteet> TteetReplies
        {
            get { return this.tteetReplies; }
            set { this.tteetReplies = value; }
        }

        protected override IEnumerable<ValidationResult> ValidateModel(ValidationContext validationContext)
        {
            var baseCollection = base.ValidateModel(validationContext);
            foreach (var item in baseCollection)
            {
                yield return item;
            }

            if (this.CreatedOn > this.LastEditedOn)
            {
                yield return new ValidationResult("A Tteet can not be edited before it was been created.", new[] { "LastEditedOn" });
            }
        }
    }
}
