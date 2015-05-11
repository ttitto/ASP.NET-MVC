namespace Ttitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Profile
    {
        ICollection<Tweet> retweetedTweets;
        ICollection<Tweet> favourizedTweets;
        ICollection<Tweet> reportedTweets;
        ICollection<Tweet> fbSharedTweets;
        ICollection<Profile> followers;
        ICollection<Profile> followed;
        ICollection<Message> sentMessages;
        ICollection<Message> receivedMessages;
        ICollection<Notification> receivedNotifications;

        public Profile()
        {
            this.Id = Guid.NewGuid();
            this.retweetedTweets = new HashSet<Tweet>();
            this.favourizedTweets = new HashSet<Tweet>();
            this.reportedTweets = new HashSet<Tweet>();
            this.fbSharedTweets = new HashSet<Tweet>();
            this.followed = new HashSet<Profile>();
            this.followers = new HashSet<Profile>();
            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.receivedNotifications = new HashSet<Notification>();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string Image { get; set; }

        [Required]
        public ProfileStatus Status { get; set; }

        [Required]
        public VisibilityStatus Visibility { get; set; }

        public Country Country { get; set; }

        public Language Language { get; set; }

        public string TimeZoneId { get; set; }

        [InverseProperty("RetweetingProfiles")]
        public virtual ICollection<Tweet> RetweetedTweets
        {
            get { return this.retweetedTweets; }
            set { this.retweetedTweets = value; }
        }

          [InverseProperty("FavourizingProfiles")]
        public virtual ICollection<Tweet> FavourizedTweets
        {
            get { return this.favourizedTweets; }
            set { this.favourizedTweets = value; }
        }

        [InverseProperty("ReportingProfiles")]
        public virtual ICollection<Tweet> ReportedTweets
        {
            get { return this.reportedTweets; }
            set { this.reportedTweets = value; }
        }

        [InverseProperty("FbSharingProfiles")]
        public virtual ICollection<Tweet> FbSharedTweets
        {
            get { return this.fbSharedTweets; }
            set { this.fbSharedTweets = value; }
        }

        public virtual ICollection<Profile> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<Profile> Followed
        {
            get { return this.followed; }
            set { this.followed = value; }
        }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

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
    }
}
