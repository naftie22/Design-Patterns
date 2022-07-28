using System.Text;

using static System.Console;

namespace Domain
{
    public class BankClient
    {
        private Bank bank;
        private bool _isdone = default;
        
        public BankClient(Bank bank)
            => this.bank = bank;
        

        public void Run()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("0 ---> Quit");
            builder.AppendLine("1 ----> Create New Account");
            builder.AppendLine("2 ----> Select Account");
            builder.AppendLine("3 ----> Deposit Money");
            builder.AppendLine("4 -----> Apply for loan");
            builder.AppendLine("5 ------> Display Account Details");
            builder.AppendLine("6 -----> Calculate Interest");
            builder.AppendLine("7 ----> Change Bank Status");
            
            string menuMessage = builder.ToString();
            while(!_isdone)
            {
                WriteLine(menuMessage);
                Write("Enter your choice >> ");
                int choice = int.Parse(Console.ReadLine());
                ProcessCommand(choice);
            }
        }

        private void ProcessCommand(int choice)
        {
            if(choice == 0)
                Quit();
            else if(choice == 1)
                CreateNewAccount();
            else if(choice == 2)
                SelectAccount();
            else if(choice == 3)
                DepositMoney();
            else if(choice == 4)
                ApplyForLoan();
            else if(choice == 5)
                DisplayAccountDetails();
            else if(choice == 6)
                CalculateInterest();
            else if(choice == 7)
                ChangeStatus();
            else
                Console.WriteLine("Invalid Choice");
        }

        private void Quit() 
        {
            _isdone = true;
            WriteLine("Thanks for using our services");
        }

        private void ChangeStatus() 
        {
            Write("Insert account number >> ");
            int accountNumber = int.Parse(Console.ReadLine());
            bank.SetStatus(accountNumber, RequestStatus());
        }
        private  void CreateNewAccount()
        {
            Status status = RequestStatus();
            int accountNumber = bank.CreateNewAccount(status);
            WriteLine($"Your account number is {accountNumber}");
        }

        private Status RequestStatus() 
        {
            WriteLine("Enter 1 for foreign, 2 for domestic: ");
            int val = int.Parse(Console.ReadLine());
            return (val == 1) ? Status.Foreign : Status.Domestic;
        }

        private void SelectAccount()
        {
            Write("Insert account number >> ");
            int accountNumber = int.Parse(Console.ReadLine());
            WriteLine(bank.SelectAccount(accountNumber));
        }

        private void DepositMoney()
        {
            Write("Insert account number >> ");
            int accountNumber = int.Parse(Console.ReadLine());

            Write("Insert amount >> ");
            int amount = int.Parse(Console.ReadLine());

            int newBalance = bank.DepositMoney(accountNumber, amount);
            WriteLine($"Your account balance is {newBalance}");
        }

        private void ApplyForLoan()
        {
            Write("Insert account number >> ");
            int accountNumber = int.Parse(Console.ReadLine());

            Write("Insert loan amount >> ");
            int loanAmount = int.Parse(Console.ReadLine());

            if(bank.ApplyForLoan(accountNumber, loanAmount))
                WriteLine("Loan approved");
            else
                WriteLine("Loan Denied!!!");
        }

        private void DisplayAccountDetails()
            => WriteLine(bank.DisplayAccountDetails());

        private void CalculateInterest()
            => bank.CalculateInterest();
    }
}