using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data;
using OnlineLibrary.Models;

namespace OnlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSubscriptionsController : ControllerBase
    {
        private readonly ApplicationDbContext g_Context;

        public BookSubscriptionsController(ApplicationDbContext context)
        {
            g_Context = context;
        }

        [HttpPost("subscribe")]
        public async Task<ActionResult<BookSubscription>> PostBookSubscription(BookSubscription bookSubscription)
        {
            g_Context.BookSubscriptions.Add(bookSubscription);
            await g_Context.SaveChangesAsync();

            return CreatedAtAction("GetBookSubscription", new { id = bookSubscription.BookSubscriptionID }, bookSubscription);
        }

        [HttpPost("unsubscribe")]
        public async Task<ActionResult<BookSubscription>> DeleteBookSubscription(BookSubscription bookSubscriptionDel)
        {
            var bookSubscriptions = await g_Context.BookSubscriptions.Where(item => item.BookID == bookSubscriptionDel.BookID && item.UserID == bookSubscriptionDel.UserID)?.ToListAsync();
            if (bookSubscriptions == null || bookSubscriptions.Count == 0)
            {
                return NotFound();
            }
            var bookSubscription = bookSubscriptions.FirstOrDefault();
            g_Context.BookSubscriptions.Remove(bookSubscription);
            await g_Context.SaveChangesAsync();
            return bookSubscription;
        }
    }
}
