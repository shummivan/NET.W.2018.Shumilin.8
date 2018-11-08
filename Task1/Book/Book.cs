using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>
    {
        #region Fields
        private string isbn;
        private string author;
        private string name;
        private string publishing;
        private string year;
        private int pages;
        private int price;
        #endregion

        #region Enums
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
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isbn">isbn</param>
        /// <param name="author">author</param>
        /// <param name="name">name</param>
        /// <param name="publishing">publishing</param>
        /// <param name="year">year</param>
        /// <param name="pages">pages</param>
        /// <param name="price">price</param>
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
        #endregion

        #region Public methods

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns>Hash code of book</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $" ISBN: {ISBN}\n Author: {Author}\n Name: {Name}\n Publishing: {Publishing}\n Year: {Year}\n Pages: {Pages}\n Price: {Price}";
        }

        /// <summary>
        /// Compare 2 book
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int Compare(Book book1, Book book2, IComparer<Book> comparer)
        {
            return comparer.Compare(book1, book2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }
            return isbn.Equals(other.isbn) && name.Equals(other.name) && author.Equals(other.author) && publishing.Equals(other.publishing) && year.Equals(other.year) && pages.Equals(other.pages) && price.Equals(other.price);
        }
        #endregion
    }
}
