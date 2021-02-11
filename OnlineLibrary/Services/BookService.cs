using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data;
using OnlineLibrary.Helpers;
using OnlineLibrary.Models;
using OnlineLibrary.Services.Interfaces;
using OnlineLibrary.ViewModels;

namespace OnlineLibrary.Services
{
    public class BookService : IBookService
    {
        private ApplicationDbContext g_dbContext;
        private IBookSubscriptionService g_IBookSubscriptionService;

        public BookService(ApplicationDbContext context, IBookSubscriptionService iBookSubscriptionService)
        {
            g_dbContext = context;
            g_IBookSubscriptionService = iBookSubscriptionService;
        }

        public IEnumerable<UserBookViewModel> GetAll(Guid userId)
        {
            List<UserBookViewModel> books = new List<UserBookViewModel>();
            g_dbContext.Books.ForEachAsync(item =>
            {
                books.Add(new UserBookViewModel(userId, g_IBookSubscriptionService)
                {
                    BookID = item.BookID,
                    Author = item.Author,
                    CoverImage = item.Author,
                    SubscriptionPrice = item.SubscriptionPrice,
                    Title = item.Author,
                    YearPublished = item.YearPublished,
                });
            }).GetAwaiter();
            return books;
        }

        public bool Create(Book book)
        {
            g_dbContext.Books.Add(book);
            return g_dbContext.SaveChanges() > 0;
        }

        public bool Clear()
        {
            g_dbContext.Books.RemoveRange(g_dbContext.Books);
            return g_dbContext.SaveChanges() > 0;
        }
    }
}