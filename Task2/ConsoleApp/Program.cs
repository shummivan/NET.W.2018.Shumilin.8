using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account;

namespace ConsoleAppAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount(1, "ivan", "shumilin", 100, 0 , BankAccount.AccountGradation.Gold,BankAccount.AccountStatus.Active);
            BankAccount acc2 = new BankAccount(2, "alex", "petrov", 200, 200, BankAccount.AccountGradation.Platinum, BankAccount.AccountStatus.Active);
            BankAccount acc3 = new BankAccount(3, "petr", "ivanov", 10, 1000, BankAccount.AccountGradation.Base, BankAccount.AccountStatus.Active);

            AccountService bls = new AccountService();

            FileWorker fw = new FileWorker("C:/Users/Shumilin/Documents/Visual Studio 2017/Projects/NET.W.2018.Shumilin.8/file2.txt");

            bls.Load(fw);

            //bls.AddAccount(acc1);
            //bls.AddAccount(acc2);
            //bls.AddAccount(acc3);

            bls.AddMoney(1, 200);

            bls.WithdrawMoney(1, 111);
            
            bls.Save(fw);

            //Console.WriteLine(acc1.ToString());
            Console.ReadKey();
        }
    }
}
