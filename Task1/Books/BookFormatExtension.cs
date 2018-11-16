using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ClassLibrary1
{
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Custom formating of book
        /// </summary>
        /// <param name="format">Format</param>
        /// <param name="arg">Argument</param>
        /// <param name="formatProvider">format provider</param>
        /// <returns>Book info format</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException();
            }
            if (arg == null)
            {
                throw new ArgumentNullException();
            }
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            Book book = arg as Book;
            logger.Info("Extension format info about book");
            switch (format.ToUpper())
            {
                case "F":
                    return $"{book.Author} {book.Name} {book.Year} {book.Publishing}";
                case "ATP":
                    return $"{book.Author} {book.Name} {book.Pages}";
                case "P":
                    return $"{book.Author} {book.Pages}";
                case "YH":
                    return $"{book.Year} {book.Publishing}";
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Current format
        /// </summary>
        /// <param name="formatType">Format type</param>
        /// <returns>Format provider</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
