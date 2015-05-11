namespace Ttitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        ICollection<Profile> retweetingProfiles;
        ICollection<Profile> favourizingProfiles;
        ICollection<Profile> reportingProfiles;
        ICollection<Profile> fbSharingProfiles;

        public Tweet()
        {
            this.Id = Guid.NewGuid();
            this.retweetingProfiles = new HashSet<Profile>();
            this.favourizingProfiles = new HashSet<Profile>();
            this.reportingProfiles = new HashSet<Profile>();
            this.fbSharingProfiles = new HashSet<Profile>();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime LastEditedOn { get; set; }

        public Guid RepliesToId { get; set; }

        [ForeignKey("RepliesToId")]
        public virtual Tweet RepliesTo { get; set; }

        [Required]
        public string Url { get; set; }

        [InverseProperty("RetweetedTweets")]
        public virtual ICollection<Profile> RetweetingProfiles {
            get { return this.retweetingProfiles; }
            set { this.retweetingProfiles = value; }
        }

        [InverseProperty("FavourizedTweets")]
        public virtual ICollection<Profile> FavourizingProfiles
        {
            get { return this.favourizingProfiles; }
            set { this.favourizingProfiles = value; }
        }

        [InverseProperty("ReportedTweets")]
        public virtual ICollection<Profile> ReportingProfiles
        {
            get { return this.reportingProfiles; }
            set { this.reportingProfiles = value; }
        }

        [InverseProperty("FbSharedTweets")]
        public virtual ICollection<Profile> FbSharingProfiles
        {
            get { return this.fbSharingProfiles; }
            set { this.fbSharingProfiles = value; }
        }
    }
}
