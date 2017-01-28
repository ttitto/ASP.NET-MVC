namespace GigHub.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public byte  Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}