namespace Ttitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Image : BaseModel
    {
        private ICollection<Profile> profiles;
        private ICollection<Tteet> tteets;

        public Image()
        {
            this.profiles = new HashSet<Profile>();
            this.tteets = new HashSet<Tteet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }

        public virtual ICollection<Profile> Profiles
        {
            get { return this.profiles; }
            set { this.profiles = value; }
        }

        public virtual ICollection<Tteet> Tteets
        {
            get { return this.tteets; }
            set { this.tteets = value; }
        }

        protected override IEnumerable<ValidationResult> ValidateModel(ValidationContext validationContext)
        {
            return base.ValidateModel(validationContext);
        }
    }
}
