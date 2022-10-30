using Library.Data;
using Library.Data.Models;
using Library.Models;
using Library.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;
        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddBook(AddBookViewModel book)
        {
            Book book_ = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Rating = book.Rating,
                CategoryId = book.CategoryId,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
            };
            await context.Books.AddAsync(book_);
            await context.SaveChangesAsync();
        }

        public async Task AddToCollection(int bookId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (book == null)
            {
                throw new ArgumentException("Invalid book ID");
            }
            if (!user.ApplicationUsersBooks.Any(m => m.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    ApplicationUser = user,
                    Book = book
                });
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var books = await context.Books.Include(x => x.Category).ToListAsync();
            return books.Select(x => new BookViewModel
            {
                Title = x.Title,
                Rating = x.Rating,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Author = x.Author,
                Category = x.Category.Name
            }).ToList();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<MyBookViewModel>> GetReadBooks(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }
            var bookIds = context.ApplicationUsersBooks.Where(x => x.ApplicationUserId == userId).ToList();
            List<MyBookViewModel> books = new List<MyBookViewModel>();
            foreach (var item in bookIds.Select(x => x.BookId).ToList())
            {
                books.Add(context.Books.Select(x => new MyBookViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Description = x.Description,
                    Category = x.Category.Name,
                    ImageUrl = x.ImageUrl
                }).First(x => x.Id == item));
            }
            return books;
        }

        public async Task RemoveFromCollection(int bookId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }
            var book = context.Books.FirstOrDefault(x => x.Id == bookId);
            if (book == null)
            {
                throw new ArgumentException("Invalid book ID");
            }
            var book_ = context.ApplicationUsersBooks.FirstOrDefault(m => m.BookId == bookId && m.ApplicationUserId == user.Id);

            if (book_ != null)
            {
                user.ApplicationUsersBooks.Remove(book_);

                await context.SaveChangesAsync();
            }
        }
    }
}
