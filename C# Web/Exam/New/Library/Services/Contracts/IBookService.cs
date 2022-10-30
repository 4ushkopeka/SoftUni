using Library.Data.Models;
using Library.Models;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();
        Task AddBook(AddBookViewModel book);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<MyBookViewModel>> GetReadBooks(string userId);
        Task AddToCollection(int bookId, string userId);
        Task RemoveFromCollection(int bookId, string userId);
    }
}
