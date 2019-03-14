using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserRegistrationPortal.CustomAttributes;

namespace UserRegistrationPortal.Models
{
    [Table("UsersInfo")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public int Id { get; set; }

        [Column("FirstName")]
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("Email")]
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [EmailAddress]
        /*[UniqueEmail]*/
        public string Email { get; set; }

        [Column("Address")]
        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Address { get; set; }

        [Column("Password")]
        [Required]
        [MinLength(8)]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [Column("ImageUrl")]
        public string Image { get; set; }

        // + Testing (User Role Comlumn) +

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        [Required]
        public Role UserRole { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}