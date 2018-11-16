using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ClassLibrary1
{
    public class BookListService
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Book list
        /// </summary>
        private List<Book> bookStore;

        /// <summary>
        /// Constructor
        /// </summary>
        public BookListService()
        {
            bookStore = new List<Book>();
            logger.Info("Book list service was created");
        }

        /// <summary>
        /// Add book
        /// </summary>
        /// <param name="book">Book</param>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            logger.Info("Book was added to list");
            bookStore.Add(book);
        }

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="book">Book</param>
        public void RemoveBook(Book book)
        {
            logger.Info("Book was deleted from list");
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            if (!bookStore.Remove(book))
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Find book by tag
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <returns>Target book</returns>
        public Book FindBookByTag(IFindBook tag)
        {
            logger.Info("Finding for a book");
            if (tag == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var item in bookStore)
            {
                if (tag.Contain(item))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Sort books by tag
        /// </summary>
        /// <param name="tag">Tag</param>
        public void SortBooksByTag(IComparer<Book> tag)
        {            
            if (tag == null)
            {
                throw new ArgumentNullException();
            }            
            bookStore.Sort(tag);
            logger.Info("List was sorted");
        }

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="store">Store</param>
        public void Save(IStorageBook store)
        {            
            store.Save(bookStore);
            logger.Info("List was saved");
        }

        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="store">Store</param>
        public void Load(IStorageBook store)
        {            
            List<Book> books = store.Load();
            foreach (var item in books)
            {
                bookStore.Add(item);
            }
            logger.Info("List was loaded");
        }
    }
}
