using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace TagClasses
{
    public class FindByAuthor : IFindBook
    {
        private string author;

        /// <summary>
        /// Find book by author
        /// </summary>
        /// <param name="author">Author</param>
        public FindByAuthor(string author)
        {
            this.author = author ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Contain 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Contain(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            return book.Author == author;
        }
    }
}
