using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.Models
{
    public class BookSubscription
    {
        [Key]
        public Guid BookSubscriptionID { get; set; }

        [Required]
        [ForeignKey("Book")]
        public Guid BookID { get; set; }
        public virtual Book Book { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
    }
}
