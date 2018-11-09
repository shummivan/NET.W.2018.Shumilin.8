using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class FileWorker : IStorageBook
    {
        /// <summary>
        /// Path
        /// </summary>
        private string path;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paths"></param>
        public FileWorker(string paths)
        {
            path = paths ?? throw new ArgumentNullException();
            if (!File.Exists(paths))
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Load data
        /// </summary>
        /// <returns>List of books</returns>
        public List<Book> Load()
        {
            List<Book> books = new List<Book>();
            string isbn;
            string name;
            string author;
            string publishing;
            string year;
            int pages;
            int price;

            using (BinaryReader reader = new BinaryReader(File.Open(path,FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    isbn = reader.ReadString();                    
                    author = reader.ReadString();
                    name = reader.ReadString();
                    publishing = reader.ReadString();
                    year = reader.ReadString();
                    pages = reader.ReadInt32();
                    price = reader.ReadInt32();
                    books.Add(new Book(isbn, author, name, publishing, year, pages, price));
                }
            }
            return books;
        }

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="books">List of books</param>
        public void Save(List<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Open)))
            {
                foreach (var item in books)
                {
                    writer.Write(item.ISBN);
                    writer.Write(item.Author);
                    writer.Write(item.Name);                    
                    writer.Write(item.Publishing);
                    writer.Write(item.Year);
                    writer.Write(item.Pages);
                    writer.Write(item.Price);
                }
            }
        }
    }
}
