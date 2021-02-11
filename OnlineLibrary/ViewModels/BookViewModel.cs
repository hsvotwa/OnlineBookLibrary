using OnlineLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.ViewModels
{
    public class UserBookViewModel
    {
        readonly IBookSubscriptionService g_bookSubscriptionService;

        public UserBookViewModel(Guid userId, IBookSubscriptionService bookSubscriptionService)
        {
            UserID = userId;
            g_bookSubscriptionService = bookSubscriptionService;
        }

        public Guid BookID { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public int YearPublished { get; set; }

        public bool Booked
        {
            get
            {
                try
                {
                    return g_bookSubscriptionService.IsSubscribed(BookID, UserID);
                }
                catch { }
                return false;
            }
        }
    }
}
