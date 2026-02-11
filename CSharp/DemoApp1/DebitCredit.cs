/*
Mini Project: Finance Management System (C#)

⸻

1. Problem Statement (Verified)

The aim of this project is to develop a menu-driven finance management system using C#, demonstrating the use of classes, functions, loops, conditional statements, and switch-case.
The project is divided into Debit and Credit operations, each handling distinct financial activities related to money outflow and inflow.

⸻

2. Project Rules (Validated)
	1.	Two classes are used:
	•	Debit
	•	Credit
	2.	Each class contains exactly four different functions.
	3.	Menu navigation is implemented using switch-case.
	4.	Decision making is implemented using if–else and logical operators.
	5.	Loops are used for repetitive calculations.
	6.	Program executes until the user selects Exit.

⸻

3. Class: Debit (Money Outflow Operations)

The Debit class handles financial activities where money is spent, deducted, or restricted.

⸻
transactions
Function 1: ATM Withdrawal Limit Validation

Purpose:
To verify whether the withdrawal amount is within the daily ATM limit.

Rules / Logic:
	•	User enters withdrawal amount.
	•	Daily withdrawal limit is fixed (₹40,000).
	•	If withdrawal amount ≤ limit → allowed.
	•	If withdrawal amount > limit → rejected.

Expected Output:
	•	“Withdrawal permitted within daily limit.”
	•	OR
	•	“Daily ATM withdrawal limit exceeded.”

⸻
Loan eligibility
Function 2: EMI Burden Evaluation

Purpose:
To determine whether a customer can manage a loan EMI.

Rules / Logic:
	•	User enters monthly income.
	•	User enters EMI amount.
	•	EMI must not exceed 40% of monthly income.
	•	EMI ≤ 40% → manageable.
	•	EMI > 40% → financial burden.

Expected Output:
	•	“EMI is financially manageable.”
	•	OR
	•	“EMI exceeds safe income limit.”

⸻
transactions
Function 3: Transaction-Based Daily Spending Calculator

Purpose:
To calculate total spending from multiple debit transactions.

Rules / Logic:
	•	User enters number of transactions.
	•	Loop runs for each transaction.
	•	Transaction amounts are summed.

Loop Used:
	•	for or while loop

Expected Output:
	•	“Total debit amount for the day: ₹XXXX”

⸻
transactions
Function 4: Minimum Balance Compliance Check

Purpose:
To check whether the account maintains the required minimum balance.

Rules / Logic:
	•	Minimum balance required: ₹2,000.
	•	User enters current balance.
	•	Balance < ₹2,000 → penalty applicable.
	•	Balance ≥ ₹2,000 → compliant.

Expected Output:
	•	“Minimum balance not maintained. Penalty applicable.”
	•	OR
	•	“Minimum balance requirement satisfied.”

⸻

4. Class: Credit (Money Inflow Operations)

The Credit class manages financial activities where money is earned, credited, or accumulated.

⸻

Function 1: Net Salary Credit Calculation

Purpose:
To calculate the net salary credited after deductions.

Rules / Logic:
	•	User enters gross salary.
	•	Fixed deduction of 10% is applied.
	•	Net salary is calculated.

Expected Output:
	•	“Net salary credited: ₹XXXX”

⸻

Function 2: Fixed Deposit Maturity Calculation

Purpose:
To calculate the maturity amount of a fixed deposit.

Rules / Logic:
	•	User enters principal, rate of interest, and time period.
	•	Simple interest is calculated.
	•	Maturity amount = Principal + Interest.

Expected Output:
	•	“Fixed Deposit maturity amount: ₹XXXX”

⸻

Function 3: Credit Card Reward Points Evaluation

Purpose:
To calculate reward points based on spending.

Rules / Logic:
	•	User enters total credit card spending.
	•	1 reward point is earned for every ₹100 spent.
	•	Reward points are calculated using division.

Expected Output:
	•	“Reward points earned: XXXX”

⸻

Function 4: Employee Bonus Eligibility Check

Purpose:
To determine bonus eligibility based on salary and experience.

Rules / Logic:
	•	Annual salary ≥ ₹5,00,000
	•	Years of service ≥ 3
	•	Both conditions must be satisfied.

Conditions Used:
	•	Logical AND (&&)

Expected Output:
	•	“Employee is eligible for bonus.”
	•	OR
	•	“Employee is not eligible for bonus.”

⸻

5. Menu System (Confirmed Correct)

Main Menu Options:
	1.	Debit Operations
	2.	Credit Operations
	3.	Exit

Rules:
	•	Menu displayed repeatedly using a loop.
	•	Selection handled using switch-case.
	•	Exit terminates the program.

⸻
*/
class DebitCredit{
    class Debit
    {
        void AtmWithdrawal()
        {
            float balance;
        	Console.WriteLine("Enter your CurrentBalance:");
        	balance=Convert.ToSingle(Console.ReadLine());
			float withdrawalAmnt;
            Console.WriteLine("Enter withdrawal amount");
            withdrawalAmnt=Convert.ToSingle(Console.ReadLine());
            if(withdrawalAmnt>0&&withdrawalAmnt<=balance&&withdrawalAmnt<=40000)
            {
                Console.WriteLine("Withdrawal permitted within daily limit");
            }
			else
			{
				Console.WriteLine("Daily ATM withdrawal limit exceeded");
			}
        }
		void LoanEligibility()
    	{
			int age;
        	int salary;
        	Console.WriteLine("Enter your age:");
        	age=Convert.ToInt32(Console.ReadLine());
        	Console.WriteLine("Enter your Salary:");
        	salary=Convert.ToInt32(Console.ReadLine());
        	if (age >= 21 && salary >= 30000)
        	{           
            	Console.WriteLine("Eligible for Loan");
				Console.WriteLine("Enter EMI amount");
				float EMI=Convert.ToSingle(Console.ReadLine());
				if(EMI <= 0.4 * salary)
				{
					Console.WriteLine("EMI is financially manageable");
				}
				else
				{
					Console.WriteLine("EMI exceeds safe income limit");
				}
        	}
        	else
        	{
            	Console.WriteLine("Not Eligible for loan");
        	}
    	}
		void BalanceCompliance()
		{
			float balance;
        	Console.WriteLine("Enter your CurrentBalance:");
        	balance=Convert.ToSingle(Console.ReadLine());
        
			if(balance<2000)
			{
				Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
			}
			else
			{
				Console.WriteLine("Minimum balance requirement satisfied.");
			}
		}
		void TransactionEntrySystem()
    	{
			float balance;
        	Console.WriteLine("Enter your CurrentBalance:");
        	balance=Convert.ToSingle(Console.ReadLine());
			Console.WriteLine("Enter number of transactions");
			int numTranc=Convert.ToInt32(Console.ReadLine());
			float total=0.0f;
			for(int i = 0; i < numTranc; i++)
			{
				float transaction=Convert.ToSingle(Console.ReadLine());
				if(transaction<0||transaction>balance)
				{
					Console.WriteLine("Invalid Teansaction");
					Console.WriteLine("Skiping this Transaction");
					continue;
				}
				balance-=transaction;
				total+=transaction;
			}
			Console.WriteLine("Total debit amount for the day : ₹{0}",total);
			Console.WriteLine("Balance after transactions : ₹{0}",balance);
		}
		public void  Menu()
        {
            int choice;
			
			Debit obj=new Debit();
			do
			{
				Console.WriteLine("Debit Menu");
				Console.WriteLine("1. ATM Withdrawal Limit Validation");
				Console.WriteLine("2. EMI Burden Evaluation");
				Console.WriteLine("3. Transactions-based daily Spending");
				Console.WriteLine("4. Minimum balance Compliance Check");
				Console.WriteLine("5. Exit");
				Console.WriteLine("Enter Choice");
				choice=Convert.ToInt32(Console.ReadLine());
				switch(choice)
				{
					case 1:
					obj.AtmWithdrawal();
					break;
					case 2:
					obj.LoanEligibility();
					break;
					case 3:
					obj.TransactionEntrySystem();
					break;
					case 4:
					obj.BalanceCompliance();
					break;
					case 5:
					Console.WriteLine("Exiting");
					break;
					default:
					Console.WriteLine("Invalid Choice");
					break;
				}
			}
			while(choice!=5);
    	}
      
    }
    class Credit
    {
        void NetSalaryCalc()
		{
			float salary;
			Console.WriteLine("Enter your Salary:");
        	salary=Convert.ToSingle(Console.ReadLine());
			float deductions=salary*0.1f;
			Console.WriteLine("Net Salary creditted: {0}",(salary-deductions));
		}
		void FixedDepositCalc()
		{
			float principal;
			int time;
			float rate;
			float interest;
			float amount;
			Console.WriteLine("Enter principal");
			principal=Convert.ToSingle(Console.ReadLine());
			Console.WriteLine("Enter rate");
			rate=Convert.ToSingle(Console.ReadLine());
			Console.WriteLine("Enter time in months");
			time=Convert.ToInt32(Console.ReadLine());
			interest=principal*time*rate/1200;
			amount=principal+interest;
			Console.WriteLine("Fixed Deposit maturity amount: ₹{0}",amount);
		}
		void CreditCardReward()
		{
			int spending;
			Console.WriteLine("Enter spending");
			spending=Convert.ToInt32(Console.ReadLine());
			int points=spending/100;
			Console.WriteLine("Reward points earned: {0}",points);
		}
		void EmployeeBonusCheck()
		{
			float salary;
			Console.WriteLine("Enter your Salary:");
        	salary=Convert.ToSingle(Console.ReadLine());
			int years;
			Console.WriteLine("Enter your Years of Service");
			years=Convert.ToInt16(Console.ReadLine());
			float annualSal=salary*12;
			if (years >= 3 && annualSal >= 500000)
			{
				Console.WriteLine("Employee is eligible for bonus.");
			}
			else
			{
				Console.WriteLine("Employee is not eligible for bonus.");
			}
			
		}
		public void Menu()
		{
			int choice;
			
			Credit obj=new Credit();
			do
			{
				Console.WriteLine("Credit Menu");
				Console.WriteLine("1. Net Salary Credit Calculation");
				Console.WriteLine("2. Fixed Deposit Maturity Calculation");
				Console.WriteLine("3. Credit Card Reward Points Evaluation");
				Console.WriteLine("4. Employee Bonus Eligibility Check");
				Console.WriteLine("5. Exit");
				Console.WriteLine("Enter Choice");
				choice=Convert.ToInt32(Console.ReadLine());
				switch(choice)
				{
					case 1:
					obj.NetSalaryCalc();
					break;
					case 2:
					obj.FixedDepositCalc();
					break;
					case 3:
					obj.CreditCardReward();
					break;
					case 4:
					obj.EmployeeBonusCheck();
					break;
					case 5:
					Console.WriteLine("Exiting");
					break;
					default:
					Console.WriteLine("Invalid Choice");
					break;
				}
			}
			while(choice!=5);
    	}
    } 
	public void MainMenu()
	{
		int choice;
		do
		{
			Console.WriteLine("Main Menu");
			Console.WriteLine("1. Debit Operations");
			Console.WriteLine("2. Credit Operations");
			Console.WriteLine("3. Exit");
			Console.WriteLine("Enter Choice");
			choice=Convert.ToInt16(Console.ReadLine());
			switch(choice)
			{
				case 1:
				new Debit().Menu();
				break;
				case 2:
				new Credit().Menu();
				break;
				case 3:
				Console.WriteLine("Exiting");
				break;
				default:
				Console.WriteLine("Invalid Choice");
				break;
			}
		}
		while(choice!=3);
    } 
}