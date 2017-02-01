namespace GigHub.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Follow
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string FollowerId { get; set; }
        public Artist Follower { get; set; }
        
        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string FollowedId { get; set; }
        public Artist Followed { get; set; }
    }
}