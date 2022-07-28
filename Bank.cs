using System.Text;

namespace Domain
{
    public class Bank
    {
        private readonly IDictionary<int, BankAccount> _accounts;
        private int _accountNumber;

        public Bank(IDictionary<int, BankAccount> accounts, int accountCounter)
        {
            this._accounts = accounts;
            this._accountNumber = accountCounter;
        }

        public int CreateNewAccount(Status status)
        {
            _accountNumber++;
            BankAccount bankAccount = new BankAccount(_accountNumber);
            bankAccount.Status = status;
            _accounts.Add(_accountNumber, bankAccount);
            return _accountNumber;
        }

        public string SelectAccount(int accountNumber)
            => _accounts[accountNumber].ToString();

        public int DepositMoney(int accountNumber, int amount)
        {
            int currentBalance = _accounts[accountNumber].Balance;
            _accounts[accountNumber].Balance = currentBalance + amount;
            return _accounts[accountNumber].Balance;
        }

        public bool ApplyForLoan(int accountNumber, int loanAmount)
        {
            int currentBalance = _accounts[accountNumber].Balance;
            return currentBalance >= loanAmount/2;
        }

        public void SetStatus(int accountNumber, Status status)
            => _accounts[accountNumber].Status = status;
        public string DisplayAccountDetails()
        {
            StringBuilder builder = new StringBuilder();
            var accounts = _accounts.Values;
            foreach(BankAccount account in accounts)
                builder.AppendLine(account.ToString());
            return builder.ToString();
        }

        public void CalculateInterest()
        {
            var accounts = _accounts.Values;
            foreach(var account in accounts)
                account.AddInterest();
        }

    }
}