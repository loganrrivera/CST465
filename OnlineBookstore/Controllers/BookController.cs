using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;
using OnlineBookstore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor to initialize the database context
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Book/Index
        public async Task<IActionResult> Index()
        {
            var books = await Task.FromResult(_context.Books.ToList());
            return View(books);
        }

        // GET: /Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await Task.FromResult(_context.Books.FirstOrDefault(m => m.Id == id));
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: /Book/Create
        public IActionResult Create()
        {
            return View(new Book());
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Description,Price,Rating,CoverImage")] Book book, IFormFile coverImage)
        {
            if (ModelState.IsValid)
            {
                if (coverImage != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", coverImage.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await coverImage.CopyToAsync(stream);
                    }

                    book.CoverImage = $"/images/{coverImage.FileName}";
                }

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        // GET: /Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await Task.FromResult(_context.Books.FirstOrDefault(m => m.Id == id));
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: /Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book, IFormFile? coverImage)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (coverImage != null && coverImage.Length > 0)
                {
                    // Check if there is an old cover image, and if so, delete it
                    if (!string.IsNullOrEmpty(book.CoverImage))
                    {
                        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Path.GetFileName(book.CoverImage));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Save the new cover image
                    var newFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", coverImage.FileName);
                    using (var stream = new FileStream(newFilePath, FileMode.Create))
                    {
                        await coverImage.CopyToAsync(stream);
                    }

                    // Update the CoverImage property to reflect the new image path
                    book.CoverImage = "/images/" + coverImage.FileName;
                }

                // Update the book in the database
                _context.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: /Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await Task.FromResult(_context.Books.FirstOrDefault(m => m.Id == id));
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            // Remove the book from the database
            _context.Books.Remove(book);
            _context.SaveChanges();

            // Redirect to Index after deletion
            return RedirectToAction(nameof(Index));
        }
    }
}
