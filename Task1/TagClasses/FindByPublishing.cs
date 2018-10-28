using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace TagClasses
{
    public class FindByPublishing :IFindBook
    {
        private string publishing;
        public FindByPublishing(string publishing)
        {
            this.publishing = publishing ?? throw new ArgumentNullException();
        }
        public bool Contain(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            return book.Publishing == publishing;
        }
    }
}
