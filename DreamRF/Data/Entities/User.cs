using System.ComponentModel.DataAnnotations;

namespace DreamRF.Data.Entities
{
public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
         [Required]
        public string LastName { get; set; }
         [Required]
        public string Username { get; set; }
         [Required]
        public byte[] PasswordHash { get; set; }
         [Required]
        public byte[] PasswordSalt { get; set; }
    }
}