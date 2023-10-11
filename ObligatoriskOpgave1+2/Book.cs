using System.Reflection.Metadata.Ecma335;

namespace ObligatoriskOpgave1_2
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } //Title must not be null and >=3 character
        public int Price { get; set; } // 0 < price <= 1200

        public Book(int id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public Book()
        {
        }

        public void ValidateTitle()
        {
            if(Title == null)
            {
                throw new ArgumentNullException("Title must not be null");
            }
            if(Title.Length < 3)
            {
                throw new ArgumentOutOfRangeException("The title must be at least 3 characters" + Title);
            }
        }

        public void ValidatePrice()
        {
            if(Price < 0 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price must be larger than 0 and max 1200" + Price);
            }
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }

        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }
    }
}