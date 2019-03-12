using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationPortal.Models
{
    [Table("ContactTypes")]
    public class ContactType
    {
        [Key]
        [Column("ContactTypeId")]
        public int Id { get; set; }

        [Column("ContactType")]
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string ContactTypeText { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}