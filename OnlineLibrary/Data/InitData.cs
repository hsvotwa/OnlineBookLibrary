using OnlineLibrary.Models;
using OnlineLibrary.Services;
using OnlineLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.Data
{
    public class InitData
    {
        readonly IBookService g_BookService;

        public InitData(IBookService bookService)
        {
            g_BookService = bookService;
        }

        public bool initBooks()
        {
            g_BookService.Clear();
            List<Book> books = new List<Book>
            {
                new Book { BookID = Guid.NewGuid(), Title = "Absalom Absalom", Author = "Unknown", CoverImage="absalom-absalom.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "A Dolls house", Author = "Unknown", CoverImage="a-Dolls-house.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Anna Karenina", Author = "Unknown", CoverImage="anna-karenina.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Beloved", Author = "Unknown", CoverImage="beloved.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Berlin Alexanderplatz", Author = "Unknown", CoverImage="berlin-alexanderplatz.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Blindness", Author = "Unknown", CoverImage="blindness.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Bostan", Author = "Unknown", CoverImage="bostan.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Buddenbrooks", Author = "Unknown", CoverImage="buddenbrooks.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Children of Gebelaw", Author = "Unknown", CoverImage="children-of-gebelawi.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Confessions of Zeno", Author = "Unknown", CoverImage="confessions-of-zeno.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Crime and punishment", Author = "Unknown", CoverImage="crime-and-punishment.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Dead souls", Author = "Unknown", CoverImage="dead-souls.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Diary of a madman", Author = "Unknown", CoverImage="diary-of-a-madman.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Don quijote de la Mancha", Author = "Unknown", CoverImage="don-quijote-de-la-mancha.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
                new Book { BookID = Guid.NewGuid(), Title = "Essais", Author = "Unknown", CoverImage="essais.jpg", SubscriptionPrice = 10M, YearPublished = 1978 },
            };
            bool success = true;
            foreach (var book in books)
            {
                if (!g_BookService.Create(book) & success)
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
