using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data;
using OnlineLibrary.Models;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext g_Context;
        private readonly IBookService g_BookService;

        public BooksController(ApplicationDbContext context, IBookService bookService)
        {
            g_Context = context;
            g_BookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            new InitData(g_BookService).initBooks();
            return await g_Context.Books.ToListAsync();
        }
    }
}
