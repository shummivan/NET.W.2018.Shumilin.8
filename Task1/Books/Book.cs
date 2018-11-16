using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Properties
        /// <summary>
        /// ISBN of book
        /// </summary>
        public string ISBN
        {
            get => isbn;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                isbn = value;
            }
        }

        /// <summary>
        /// Author of book
        /// </summary>
        public string Author
        {
            get => author;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                author = value;
            }
        }

        /// <summary>
        /// Name of book
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                name = value;
            }
        }

        /// <summary>
        /// Publishing house of book
        /// </summary>
        public string Publishing
        {
            get => publishing;            
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                publishing = value;
            }
        }

        /// <summary>
        /// Year of book
        /// </summary>
        public string Year
        {
            get => year;
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                year = value;
            }
        }

        /// <summary>
        /// Pages count of book
        /// </summary>
        public int Pages
        {
            get => pages;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                pages = value;
            }
        }

        /// <summary>
        /// Price of book
        /// </summary>
        public int Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
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
            logger.Info("Book instance was createвd");
        }
        #endregion

        #region Public methods

        public override string ToString()
        {
            logger.Info("Default info about book");
            return ToString("AT", null);
        }

        public string ToString(string format)
        {
            logger.Info("Format info about book");
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException();
            }

            logger.Info("Different format info about book");
            switch (format.ToUpper())
            {
                case "ATYH":
                    return $"{Author} {Name} {Year} {Publishing}";
                case "ATY":
                    return $"{Author} {Name} {Year}";
                case "AT":
                    return $"{Author} {Name}";
                case "TYH":
                    return $"{Name} {Year} {Publishing}";
                case "T":
                    return $"{Name}";
                default:
                    throw new Exception();
            }
        }

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
