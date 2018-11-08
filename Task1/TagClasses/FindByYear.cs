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

        /// <summary>
        /// Find book by year
        /// </summary>
        /// <param name="year"></param>
        public FindByYear(string year)
        {
            this.year = year ?? throw new ArgumentNullException();
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
            return book.Year == year;
        }
    }
}
