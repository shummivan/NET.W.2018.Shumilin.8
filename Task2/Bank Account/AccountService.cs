using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account;

namespace Account
{
    public class AccountService
    {
        private List<BankAccount> accountStore;

        public AccountService()
        {
            accountStore = new List<BankAccount>();
        }

        public void AddAccount(BankAccount acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException();
            }
            accountStore.Add(acc);
        }

        public void RemoveAccount(BankAccount acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException();
            }
            if (!accountStore.Remove(acc))
            {
                throw new ArgumentException();
            }
        }

        public void CloseAccount(BankAccount acc)
        {
            acc.Status = BankAccount.AccountStatus.Closed;
        }

        public void ActivateAccount(BankAccount acc)
        {
            acc.Status = BankAccount.AccountStatus.Active;
        }

        public BankAccount GetAccount(int id)
        {
            return accountStore.FirstOrDefault(ba => ba.Id == id);            
        }

        public void Save(IStorageAccount store)
        {
            store.Save(accountStore);
        }

        public void Load(IStorageAccount store)
        {
            List<BankAccount> books = store.Load();
            foreach (var item in books)
            {
                accountStore.Add(item);
            }
        }

        public void AddMoney(int id, decimal money)
        {
            var account = GetAccount(id);
            if (money <= 0 || account == null || account.Status == BankAccount.AccountStatus.Closed)
            {
                throw new ArgumentException();
            }
            account.Amount += money;
            account.Bonus += BonusPoints(account.Gradation, money);
        }

        public void WithdrawMoney(int id, decimal money)
        {
            var account = GetAccount(id);
            if (money <= 0 || account.Amount < money || account == null || account.Status == BankAccount.AccountStatus.Closed)
            {
                throw new ArgumentException();
            }
            account.Amount -= money;
            account.Bonus -= BonusPoints(account.Gradation, money);
        }

        private static int BonusPoints(BankAccount.AccountGradation accountGradation, decimal amount)
        {
            switch (accountGradation)
            {
                case BankAccount.AccountGradation.Base:
                    amount = amount / 100;
                    return (int)amount;                    
                case BankAccount.AccountGradation.Gold:
                    amount = amount / 100 * 2;
                    return (int)amount;
                case BankAccount.AccountGradation.Platinum:
                    amount = amount / 100 * 4;
                    return (int)amount;
            }
            return (int)amount;
        }
    }
}
