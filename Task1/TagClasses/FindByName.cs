using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace TagClasses
{
    public class FindByName : IFindBook
    {
        private string name;
        public FindByName(string name)
        {
            this.name = name ?? throw new ArgumentNullException();
        }
        public bool Contain(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            return book.Name == name;
        }
    }
}
