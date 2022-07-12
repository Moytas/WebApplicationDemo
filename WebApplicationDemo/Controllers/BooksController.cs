using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        List<Book> Books = new List<Book>();
        DBHelper Db = new DBHelper();
        private readonly WebApplicationDemoContext _context;


       
        public BooksController(WebApplicationDemoContext context)
        {
            _context = context;
            Books.Add(new Book { BookID = 1, BookType = "Essay", Title = "An essay" });
            Books.Add(new Book { BookID = 2, BookType = "Tutorials", Title = "Intro to c#" });

        }

        // GET: api/Books
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        public List<Student> GetBook()
        {
           
          //  if (_context.Book == null)
          //{
          //    return NotFound();
          //}
          //  return await _context.Book.ToListAsync();
          return Db.GetAll();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Book>> GetBook(int id)
        public Book GetBook(int id)
        {
            //if (_context.Book == null)
            //{
            //    return NotFound();
            //}
            //  var book = await _context.Book.FindAsync(id);

            //  if (book == null)
            //  {
            //      return NotFound();
            //  }
            Console.WriteLine("ok2");
            return Books.Where(b => b.BookID == id).FirstOrDefault();
        }

        [Route("api/add")]
        [HttpPut("{name}")]
        public void AddBook(string name)
        {
            Console.WriteLine("ok");
            Book newBook = new Book();
            newBook.BookID = 5;
            newBook.Title = name;
            Db.Add(newBook);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // public async Task<IActionResult> PutBook(int id, Book book)
        [HttpPut("{name}")]
        [Route("api/put/{name}")]
        public void PutBook(string name)
        {
            Console.WriteLine("ok");
            Book newBook = new Book();
            newBook.BookID = 5;
            newBook.Title = name;
            Books.Add(newBook);
            //if (id != book.BookID)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(book).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BookExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
          if (_context.Book == null)
          {
              return Problem("Entity set 'WebApplicationDemoContext.Book'  is null.");
          }
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookID }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Book == null)
            {
                return NotFound();
            }
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return (_context.Book?.Any(e => e.BookID == id)).GetValueOrDefault();
        }
    }
}
