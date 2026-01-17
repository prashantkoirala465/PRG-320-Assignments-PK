using System;

static class BankingSystem
{
    static decimal balance = 0.0m;

    const string correctPin = "1234"; 

    public static void Run()
    {
        // Don’t allow user to use banking menu unless PIN is correct.
        if (!Login())
        {
            Console.WriteLine("Too many failed attempts. System locked.");
            return;
        }

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- BANKING SYSTEM ---");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Balance Inquiry");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Choose an option: ");

            // TryParse prevents crashing if user types random text.
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Enter a number from 1 to 4.");
                continue;
            }

            // Switch is required by syllabus for menu handling.
            switch (choice)
            {
                case 1:
                    Deposit();
                    break;

                case 2:
                    Withdraw();
                    break;

                case 3:
                    BalanceInquiry();
                    break;

                case 4:
                    exit = true; // exit banking module only
                    break;

                default:
                    Console.WriteLine("Choose between 1 and 4.");
                    break;
            }
        }
    }

    static bool Login()
    {
        int attempts = 0;

        // Max 3 tries, then lock out.
        while (attempts < 3)
        {
            Console.Write("Enter PIN: ");
            string enteredPin = Console.ReadLine() ?? "";

            if (enteredPin == correctPin)
            {
                Console.WriteLine("Login successful!");
                return true;
            }

            attempts++;
            Console.WriteLine($"Wrong PIN. Attempts left: {3 - attempts}");
        }

        return false;
    }

    static void Deposit()
    {
        // Amount must be positive, otherwise deposit doesn’t make sense.
        decimal amount = ReadPositiveAmount("Enter deposit amount: ");
        balance += amount;

        Console.WriteLine($"Deposit successful. New balance: {balance:N2}");
    }

    static void Withdraw()
    {
        decimal amount = ReadPositiveAmount("Enter withdrawal amount: ");

        // Core rule: no overdraft allowed.
        if (amount > balance)
        {
            Console.WriteLine("Error: Insufficient funds. You cannot withdraw more than your balance.");
            Console.WriteLine($"Current balance: {balance:N2}");
            return;
        }

        balance -= amount;
        Console.WriteLine($"Withdrawal successful. New balance: {balance:N2}");
    }

    static void BalanceInquiry()
    {
        Console.WriteLine($"Current balance: {balance:N2}");
    }

    static decimal ReadPositiveAmount(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            // Decimal is better for money than double because it avoids rounding issues.
            if (decimal.TryParse(input, out decimal amount) && amount > 0)
                return amount;

            Console.WriteLine("Invalid amount. Enter a positive number.");
        }
    }
}
