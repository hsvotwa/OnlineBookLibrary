using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data;
using OnlineLibrary.Helpers;
using OnlineLibrary.Models;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services
{
    public class BookSubscriptionService : IBookSubscriptionService
    {
        private ApplicationDbContext g_dbContext;

        public BookSubscriptionService(ApplicationDbContext context)
        {
            g_dbContext = context;
        }

        public bool Subscribe(Guid bookId, Guid userId)
        {
            g_dbContext.BookSubscriptions.Add(
               new BookSubscription
               {
                   BookID = bookId,
                   UserID = userId,
                   BookSubscriptionID = Guid.NewGuid()
               });
            return g_dbContext.SaveChanges() > 0;
        }

        public bool IsSubscribed(Guid bookId, Guid userId)
        {
            return g_dbContext.BookSubscriptions.Any(item => item.BookID == bookId && item.UserID == userId);
        }
    }
}