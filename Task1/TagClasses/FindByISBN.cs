using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


namespace TagClasses
{
    public class FindByISBN : IFindBook
    {
        private string isbn;

        /// <summary>
        /// Find book by isbn
        /// </summary>
        /// <param name="isbn"></param>
        public FindByISBN(string isbn)
        {
            this.isbn = isbn ?? throw new ArgumentNullException();
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
            return book.ISBN == isbn;
        }
    }
}
