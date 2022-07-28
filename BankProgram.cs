using System.Text;
using static System.Console;
namespace Domain 
{
    public class BankProgram
    {
        private Dictionary<int, int> _accounts = new Dictionary<int, int>();
        private double _rate = 0.01;
        private int _newAccountNumber = 0;
        
        private bool _isdone = default;


        public static void Main()
        {
            BankProgram bankProgram = new ();
            bankProgram.run();
        
        }

        public void run()
        {
            StringBuilder builder = new ();
            builder.AppendLine("0 ---> Quit");
            builder.AppendLine("1 ---> Create New Account");
            builder.AppendLine("2 ---> Select Account");
            builder.AppendLine("3 ---> Deposit Money");
            builder.AppendLine("4 ---> Apply for loan");
            builder.AppendLine("5 ---> Display Account Details");
            builder.AppendLine("6 ---> Calculate Interest");
            
            string menuMessage = builder.ToString();
            WriteLine(menuMessage);
            while(!_isdone)
            {
                Write("Hola! Welcome to BankYo App please enter your choice >> ");
                 int choice = int.Parse(ReadLine());
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
            else
                WriteLine("Invalid Choice");
        }
          private void Quit() 
        {
            _isdone = true;
            WriteLine("Thanks for using BankYo services see you soon");
        }
         private  void CreateNewAccount()
        {
            _newAccountNumber++;
            _accounts.Add(_newAccountNumber, 0);
            WriteLine($"Your account number is {_newAccountNumber}");
        }
        private void SelectAccount()
        {
            Write("Insert account number >> ");
            int accountNumber = int.Parse(ReadLine());
            WriteLine($"Your BankYo accountnumber is :{accountNumber} and your balance is :{_accounts[accountNumber]}");
            
        }
        private void DepositMoney()
        {
            Write("Insert account number >> ");
            int accountNumber = int.Parse(ReadLine());

            Write("Insert amount >> ");
            int amount = int.Parse(ReadLine());

            int newBalance = _accounts[accountNumber] + amount;
            _accounts[accountNumber] = newBalance;
            WriteLine($"Your account balance is {newBalance}");
        }
        private void ApplyForLoan()
        {
            Write("Insert account number >> ");
            int accountNumber = int.Parse(ReadLine());

            Write("Insert loan amount >> ");
            int loanAmount = int.Parse(ReadLine());
            int balance = _accounts[accountNumber];

            if(balance >= loanAmount/2)
                WriteLine("Loan approved");
            else
                WriteLine("Loan Denied!!!");
        }
        public string DisplayAccountDetails()
        {
            StringBuilder builder = new StringBuilder();
            var accountNumbers = _accounts.Keys;
            foreach(int accountNumber in accountNumbers)
                builder.AppendLine($"Your AccountNumber is : {accountNumber} and your balance is : {_accounts[accountNumber]}");
            return builder.ToString();
        }
        public void CalculateInterest() 
        {
             var accountNumbers = _accounts.Keys;
            foreach(var accountNumber in accountNumbers)
            {
                int balance = _accounts[accountNumber];
                _accounts[accountNumber] += (int) (balance * _rate);
            }
        }
             
    }
}
