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
        public FindByAuthor(string author)
        {
            this.author = author ?? throw new ArgumentNullException();
        }
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
