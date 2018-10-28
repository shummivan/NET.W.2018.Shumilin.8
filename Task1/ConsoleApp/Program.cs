using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using TagClasses;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("123-123", "pushkin", "slovo", "piter", "2018", 500, 100);
            Book book2 = new Book("321-321", "lermontov", "borodino", "piter", "2016", 300, 300);
            Book book3 = new Book("666-666", "gogol", "vij", "mosk", "1999", 102, 30);
            Book book4 = new Book("666-666", "pushkin", "vij", "mosk", "1999", 102, 30);
            BookListService bls = new BookListService();

            Console.WriteLine(book1.Equals(book1));
            Console.WriteLine(book1.Equals(book2));

            FileWorker fw = new FileWorker("C:/Users/Shumilin/Documents/Visual Studio 2017/Projects/NET.W.2018.Shumilin.8/file.txt");
            bls.Load(fw);

            //bls.AddBook(book1);
            //bls.AddBook(book2);
            //bls.AddBook(book1);
            //bls.AddBook(book3);
            //bls.RemoveBook(book1);

            //bls.Save(fw);

            Console.WriteLine(Book.Compare(book1, book2, new CompareByAuthor()));

            var t = bls.FindBookByTag(new FindByAuthor("123"));

            Console.WriteLine(t);

            //Console.WriteLine(book1.ToString());

            Console.ReadKey();
        }
    }
}
