using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Account
{
    public class FileWorker : IStorageAccount
    {
        /// <summary>
        /// File path
        /// </summary>
        private string path;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paths">Paths</param>
        public FileWorker(string paths)
        {
            path = paths ?? throw new ArgumentNullException();
            if (!File.Exists(paths))
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Load data
        /// </summary>
        /// <returns>Data list</returns>
        public List<BankAccount> Load()
        {
            List<BankAccount> acc = new List<BankAccount>();
            int id;
            string firstName;
            string lastName;
            decimal amount;
            int bonus;
            BankAccount.AccountGradation gradation;
            BankAccount.AccountStatus status;

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    id = reader.ReadInt32();
                    firstName = reader.ReadString();
                    lastName = reader.ReadString();
                    amount = reader.ReadDecimal();
                    bonus = reader.ReadInt32();
                    gradation = (BankAccount.AccountGradation)reader.ReadInt32();
                    status = (BankAccount.AccountStatus)reader.ReadInt32();
                    acc.Add(new BankAccount(id, firstName, lastName, amount, bonus, gradation, status));
                }
            }
            return acc;
        }

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="books">List of books</param>
        public void Save(List<BankAccount> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Open)))
            {
                foreach (var item in books)
                {
                    writer.Write(item.Id);
                    writer.Write(item.FirstName);
                    writer.Write(item.LastName);
                    writer.Write(item.Amount);
                    writer.Write(item.Bonus);
                    writer.Write((int)item.Gradation);
                    writer.Write((int)item.Status);
                }
            }
        }
    }
}
