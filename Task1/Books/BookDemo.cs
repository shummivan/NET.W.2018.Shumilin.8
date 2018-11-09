using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class BookDemo : IComparable, IComparable<BookDemo>, IEquatable<BookDemo>
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
                if (String.IsNullOrEmpty(value))
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
        public BookDemo(string isbn, string author, string name, string publishing, string year, int pages, int price)
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
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString("AT", null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formatting out string
        /// </summary>
        /// <param name="format">Format</param>
        /// <param name="formatProvider">formatProvider</param>
        /// <returns>Formatting string</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException();
            }

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
                BookDemo book = (BookDemo)obj;
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
        public static int Compare(BookDemo book1, BookDemo book2, IComparer<BookDemo> comparer)
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
            BookDemo book = obj as BookDemo;
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
        public int CompareTo(BookDemo other)
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
        public bool Equals(BookDemo other)
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
