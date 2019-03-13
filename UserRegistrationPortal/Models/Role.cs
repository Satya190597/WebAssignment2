using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// + Testing This Model +
namespace UserRegistrationPortal.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [Column("RoleId")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string RoleType { get; set; }
        public ICollection<User> Users { get; set; }
    }
}