using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationPortal.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        [Column("ContactId")]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }

        
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [Column("ContactNumber")]
        public string ContactNumber { get; set; }

        public int ContactTypeId { get; set; }

        [ForeignKey("ContactTypeId")]
        [Required]
        public ContactType ContactType { get; set; }
    }
}