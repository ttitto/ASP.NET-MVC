namespace Ttitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Profile :BaseModel
    {
        ICollection<Tteet> retteetedTteets;
        ICollection<Tteet> favouriteTteets;
        ICollection<Tteet> reportedTteets;
        ICollection<Tteet> fbSharedTteets;
        ICollection<Profile> followers;
        ICollection<Profile> followed;
        ICollection<Message> sentMessages;
        ICollection<Message> receivedMessages;
        ICollection<Notification> receivedNotifications;

        public Profile()
        {
            this.retteetedTteets = new HashSet<Tteet>();
            this.favouriteTteets = new HashSet<Tteet>();
            this.reportedTteets = new HashSet<Tteet>();
            this.fbSharedTteets = new HashSet<Tteet>();
            this.followed = new HashSet<Profile>();
            this.followers = new HashSet<Profile>();
            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.receivedNotifications = new HashSet<Notification>();
        }

        [Required(ErrorMessageResourceName="Id", ErrorMessage="Profile Id is required")]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName="Name", ErrorMessage="Profile Name is required")]
        [StringLength(40, MinimumLength = 5, ErrorMessage="Profile Name should be between 5 and 40 characters")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "UserId", ErrorMessage = "Profile UserId is required")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int? ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }

        [Required(ErrorMessageResourceName = "Status", ErrorMessage = "Profile Status is required")]
        public ProfileStatus Status { get; set; }

        [Required(ErrorMessageResourceName = "Visibility", ErrorMessage = "Profile Visibility is required")]
        public VisibilityStatus Visibility { get; set; }

        public Country Country { get; set; }

        public Language Language { get; set; }

        public string TimeZoneId { get; set; }

        [Column("RetteetedTteets")]
        [InverseProperty("RetteetingProfiles")]
        public virtual ICollection<Tteet> RetteetedTteets
        {
            get { return this.retteetedTteets; }
            set { this.retteetedTteets = value; }
        }

        [Column("FavouriteTteets")]
        [InverseProperty("FavourizingProfiles")]
        public virtual ICollection<Tteet> FavouriteTteets
        {
            get { return this.favouriteTteets; }
            set { this.favouriteTteets = value; }
        }

        [Column("ReportedTteets")]
        [InverseProperty("ReportingProfiles")]
        public virtual ICollection<Tteet> ReportedTteets
        {
            get { return this.reportedTteets; }
            set { this.reportedTteets = value; }
        }

        [Column("FbSharedTteets")]
        [InverseProperty("FbSharingProfiles")]
        public virtual ICollection<Tteet> FbSharedTteets
        {
            get { return this.fbSharedTteets; }
            set { this.fbSharedTteets = value; }
        }

        [InverseProperty("Followed")]
        public virtual ICollection<Profile> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        [InverseProperty("Followers")]
        public virtual ICollection<Profile> Followed
        {
            get { return this.followed; }
            set { this.followed = value; }
        }

        [Column("SentMessages")]
        [InverseProperty("SenderProfile")]
        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        [Column("ReceivedMessages")]
        [InverseProperty("ReceiverProfile")]
        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        public virtual ICollection<Notification> ReceivedNotifications
        {
            get { return this.receivedNotifications; }
            set { this.receivedNotifications = value; }
        }

        protected override IEnumerable<ValidationResult> ValidateModel(ValidationContext validationContext)
        {
            return base.ValidateModel(validationContext);
        }
    }
}
