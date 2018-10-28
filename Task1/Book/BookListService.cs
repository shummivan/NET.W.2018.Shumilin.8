using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BookListService
    {
        private List<Book> bookStore;

        public BookListService()
        {
            bookStore = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            bookStore.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            if (!bookStore.Remove(book))
            {
                throw new ArgumentException();
            }
        }

        public Book FindBookByTag(IFindBook tag)
        {
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

        public void SortBooksByTag(IComparer<Book> tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException();
            }
            bookStore.Sort(tag);
        }

        public void Save(IStorageBook store)
        {
            store.Save(bookStore);
        }

        public void Load(IStorageBook store)
        {
            List<Book> books = store.Load();
            foreach (var item in books)
            {
                bookStore.Add(item);
            }
        }
    }
}
