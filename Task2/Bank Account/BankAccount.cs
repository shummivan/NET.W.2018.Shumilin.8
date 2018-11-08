using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public class BankAccount
    {
        #region Fields
        private int id;
        private string firstName;
        private string lastName;
        private decimal amount;
        private int bonus;
        private AccountGradation gradation;
        private AccountStatus status;
        #endregion

        #region Enums
        public enum AccountGradation
        {
            Base,
            Gold,
            Platinum
        }
        public enum AccountStatus
        {
            Active,
            Closed
        }
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set
            {
                id = value;
            }

        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                lastName = value;
            }
        }
        public decimal Amount
        {
            get => amount;
            set
            {
                if (amount < 0)
                {
                    throw new ArgumentNullException();
                }
                amount = value;
            }
        }
        public int Bonus
        {
            get => bonus;
            set
            {
                if (amount < 0)
                {
                    throw new ArgumentNullException();
                }
                bonus = value;
            }
        }
        public AccountGradation Gradation { get; set; }
        public AccountStatus Status { get; set; }
        #endregion

        #region Constructor
        public BankAccount(int id, string firstName, string lastName, decimal amount, int bonus, AccountGradation gradation, AccountStatus status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Amount = amount;
            Bonus = bonus;
            Gradation = gradation;
            Status = status;
        }
        #endregion

        public override string ToString()
        {
            return $" Id: {Id}\n First Name: {FirstName}\n LastName: {LastName}\n Amount: {Amount}\n Bonus: {Bonus}\n Gradation: {Gradation}\n Status: {Status}";
        }
    }
}
