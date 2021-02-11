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
        private readonly ApplicationDbContext _context;

        public BookSubscriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<BookSubscription>> PostBookSubscription(BookSubscription bookSubscription)
        {
            _context.BookSubscriptions.Add(bookSubscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookSubscription", new { id = bookSubscription.BookSubscriptionID }, bookSubscription);
        }

        // DELETE: api/BookSubscriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookSubscription>> DeleteBookSubscription(Guid id)
        {
            var bookSubscription = await _context.BookSubscriptions.FindAsync(id);
            if (bookSubscription == null)
            {
                return NotFound();
            }

            _context.BookSubscriptions.Remove(bookSubscription);
            await _context.SaveChangesAsync();

            return bookSubscription;
        }
    }
}
