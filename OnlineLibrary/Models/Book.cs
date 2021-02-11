using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.Models
{
    public class Book
    {
        [Key]
        public Guid BookID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string CoverImage { get; set; }

        [Required]
        public decimal SubscriptionPrice { get; set; }

        [Required]
        public int YearPublished { get; set; }
    }
}
