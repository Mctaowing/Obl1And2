using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave1_2
{
    public interface IBookRepository
    {
        Book AddBook (Book book);
        IEnumerable<Book> GetAllBooks (int? priceAfter = null, int? priceBefore = null, string? titleIncludes = null, string? orderBy = null);
        Book? GetBookById(int id);
        Book? DeleteBook(int id);
        Book? UpdateBook(int id, Book book);
    }
}
