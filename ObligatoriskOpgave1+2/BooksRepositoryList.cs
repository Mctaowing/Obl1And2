using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave1_2
{
    public class BooksRepositoryList : IBookRepository
    {
        private int _nextId = 1;
        private readonly List<Book> _books = new();

        public BooksRepositoryList()
        {
            
        }

        public IEnumerable<Book> GetAllBooks(int? priceAfter = null, int? priceBefore = null, string? titleIncludes = null, string? orderBy = null) 
        {
            IEnumerable<Book> result = new List<Book>(_books);
            //Filtrering
            if(priceAfter != null)
            {
                result = result.Where(b => b.Price > priceAfter);
            }
            if(priceBefore != null)
            {
                result = result.Where(b => b.Price < priceBefore);
            }
            if(titleIncludes != null)
            {
                result = result.Where(b => b.Title.Contains(titleIncludes));
            }
            //Sortering
            if(orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "title":
                    case "title_asc":
                        result = result.OrderBy(b => b.Title);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(b => b.Title);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(b => b.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(b => b.Price);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public Book? GetBookById(int id)
        {
            return _books.Find(book => book.Id == id);
        }

        public Book AddBook(Book book)
        {
            book.Validate();
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? DeleteBook(int id)
        {
            Book? book = GetBookById(id);
            if (book == null) 
            {
                return null;
            }
            _books.Remove(book);
            return book;
        }

        public Book? UpdateBook(int id, Book book)
        {
            book.Validate();
            Book? existingBook = GetBookById(id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            return existingBook;
        }
    }
}
