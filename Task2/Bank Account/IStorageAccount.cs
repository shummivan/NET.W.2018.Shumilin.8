using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public interface IStorageAccount
    {
        void Save(List<BankAccount> books);
        List<BankAccount> Load();
    }
}
