using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace TagClasses
{
    public class FindByYear : IFindBook
    {
        private string year;
        public FindByYear(string year)
        {
            this.year = year ?? throw new ArgumentNullException();
        }
        public bool Contain(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            return book.Year == year;
        }
    }
}
