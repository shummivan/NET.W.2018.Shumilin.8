using System;
using NUnit.Framework;
using Books;

namespace Books.NUnitTests
{
    [TestFixture]
    public class BookTests
    {
        BookDemo book1 = new BookDemo("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2012", 826, 59);

        [TestCase("ATYH", ExpectedResult = "Jeffrey Richter CLR via C# 2012 Microsoft Press")]
        [TestCase("ATY", ExpectedResult = "Jeffrey Richter CLR via C# 2012")]
        [TestCase("AT", ExpectedResult = "Jeffrey Richter CLR via C#")]
        [TestCase("TYH", ExpectedResult = "CLR via C# 2012 Microsoft Press")]
        [TestCase("T", ExpectedResult = "CLR via C#")]
        public string ToString_ValidFormat_ValidResult(string format)
        {
            return book1.ToString(format);
        }

        [TestCase("AASDASCA")]
        [TestCase("SAD")]
        public void Format_InvalidFormat_FormatException(string format)
            => Assert.Throws<Exception>(() => new BookFormatExtension().Format(format, book1, null));

        [TestCase("F", ExpectedResult = "978-0-7356-6745-7 Jeffrey Richter CLR via C# Microsoft Press 2012 826 59")]
        [TestCase("ATP", ExpectedResult = "Jeffrey Richter CLR via C# 826")]
        [TestCase("P", ExpectedResult = "826")]
        [TestCase("YH", ExpectedResult = "2012 Microsoft Press")]
        public string Format_ValidFormat_ValidResult(string format)
        {
            return new BookFormatExtension().Format(format, book1, null);
        }

        [TestCase("AASDASCA")]
        [TestCase("SAD")]
        public void FormatExtension_InvalidFormat_FormatException(string format)
            => Assert.Throws<Exception>(() => new BookFormatExtension().Format(format, book1, null));
    }
}
