using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace TagClasses
{
    public class CompareByPublishing : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Publishing.CompareTo(y.Publishing);
        }
    }
}
