using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}