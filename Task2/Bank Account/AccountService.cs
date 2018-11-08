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
        /// <summary>
        /// List of account
        /// </summary>
        private List<BankAccount> accountStore;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountService()
        {
            accountStore = new List<BankAccount>();
        }

        /// <summary>
        /// Add account
        /// </summary>
        /// <param name="acc">Account</param>
        public void AddAccount(BankAccount acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException();
            }
            accountStore.Add(acc);
        }

        /// <summary>
        /// Remove Account
        /// </summary>
        /// <param name="acc">Account</param>
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

        /// <summary>
        /// Close account
        /// </summary>
        /// <param name="acc">Account</param>
        public void CloseAccount(BankAccount acc)
        {
            acc.Status = BankAccount.AccountStatus.Closed;
        }

        /// <summary>
        /// Activate account
        /// </summary>
        /// <param name="acc">Account</param>
        public void ActivateAccount(BankAccount acc)
        {
            acc.Status = BankAccount.AccountStatus.Active;
        }

        /// <summary>
        /// Get account
        /// </summary>
        /// <param name="id">Account id</param>
        /// <returns>Account</returns>
        public BankAccount GetAccount(int id)
        {
            return accountStore.FirstOrDefault(ba => ba.Id == id);            
        }

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="store">Store</param>
        public void Save(IStorageAccount store)
        {
            store.Save(accountStore);
        }

        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="store">Store</param>
        public void Load(IStorageAccount store)
        {
            List<BankAccount> books = store.Load();
            foreach (var item in books)
            {
                accountStore.Add(item);
            }
        }

        /// <summary>
        /// Add money
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="money">Money</param>
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

        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="money">Money</param>
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

        /// <summary>
        /// Calculate bonus points
        /// </summary>
        /// <param name="accountGradation">Account gradation</param>
        /// <param name="amount">Amount</param>
        /// <returns>Bonus points</returns>
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
