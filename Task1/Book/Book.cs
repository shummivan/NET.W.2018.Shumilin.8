using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>
    {
        private string isbn;
        private string author;
        private string name;
        private string publishing;
        private string year;
        private int pages;
        private int price;

        public string ISBN
        {
            get => isbn;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception();
                }
                isbn = value;
            }
        }
        public string Author
        {
            get => author;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception();
                }
                author = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception();
                }
                name = value;
            }
        }
        public string Publishing
        {
            get => publishing;            
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception();
                }
                publishing = value;
            }
        }
        public string Year
        {
            get => year;
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new Exception();
                }
                year = value;
            }
        }
        public int Pages
        {
            get => pages;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("");
                }
                pages = value;
            }
        }
        public int Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("");
                }
                price = value;
            }
        }

        public Book(string isbn, string author, string name, string publishing, string year, int pages, int price)
        {
            ISBN = isbn;
            Author = author;
            Name = name;
            Publishing = publishing;
            Year = year;
            Pages = pages;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Book book = (Book) obj;
                return (isbn == book.isbn) && (name == book.name) && (author == book.author) && (publishing == book.publishing) && (year == book.year) && (pages == book.pages) && (price == book.price);
            }        
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $" ISBN: {ISBN}\n Author: {Author}\n Name: {Name}\n Publishing: {Publishing}\n Year: {Year}\n Pages: {Pages}\n Price: {Price}";
        }

        public static int Compare(Book book1, Book book2, IComparer<Book> comparer)
        {
            return comparer.Compare(book1, book2);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Book book = obj as Book;
            if (book != null)
            {
                return Name.CompareTo(book.Name);
            }
            else
            {
                throw new Exception();
            }
        }

        public int CompareTo(Book other)
        {
            if (other == null)
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }
            return isbn.Equals(other.isbn) && name.Equals(other.name) && author.Equals(other.author) && publishing.Equals(other.publishing) && year.Equals(other.year) && pages.Equals(other.pages) && price.Equals(other.price);
        }
    }
}
