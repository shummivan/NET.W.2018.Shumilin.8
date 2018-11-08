using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace TagClasses
{
    public class CompareByAuthor : IComparer<Book>
    {
        /// <summary>
        /// Compare by author
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Book x, Book y)
        {
            return x.Author.CompareTo(y.Author);
        }
    }
}
