namespace Domain
{
    public enum Status
    {
        Domestic, Foreign
    }

    public class BankAccount
    {
        public int AccountNumber { get; init; }
        public int Balance { get; set; }
        public Status Status { get; set; }

        private double _rate = 0.01;

        public BankAccount(int accountNumber)
            => this.AccountNumber = accountNumber;

        public void DepositMoney(int amount) 
            => Balance += amount;

        public bool hasEnoughCollateral(int loanAmount) 
            => Balance >= loanAmount/2;

        public override string ToString()
            => $"Account Number: {AccountNumber} Account Balance: {Balance} Account Status: {Status}";

        public void AddInterest() 
            => Balance += (int) (Balance * _rate);
    }
}