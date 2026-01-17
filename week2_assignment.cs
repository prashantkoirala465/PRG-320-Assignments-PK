using System;

class Program
{
    // Using a single balance variable
    static double balance = 0.0;

    // Hardcoded PIN just for this assignment
    static string correctPin = "1234";

    static void Main(string[] args)
    {
        // User must pass PIN check before seeing the banking menu
        if (!Login())
        {
            Console.WriteLine("Too many failed attempts. System locked.");
            return; // stop program if login fails
        }

        bool exit = false;

        // Keep showing menu until user chooses Exit
        while (!exit)
        {
            Console.WriteLine("\nBanking Menu:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Balance Inquiry");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            // TryParse prevents crash if user types letters instead of numbers
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Enter a number from 1 to 4.");
                continue;
            }

            // Switch is clean for fixed menu options 
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
                    exit = true; // this ends the loop and exits the program
                    Console.WriteLine("Goodbye!");
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

        // Allow only 3 attempts, like a basic lockout rule
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

        // If we reach here, all attempts are used
        return false;
    }

    static void Deposit()
    {
        // Deposit must be positive, so we reuse the same validation helper
        double amount = ReadPositiveAmount("Enter deposit amount: ");

        balance += amount; // deposit increases balance
        Console.WriteLine($"Deposit successful. New balance: {balance:F2}");
    }

    static void Withdraw()
    {
        double amount = ReadPositiveAmount("Enter withdrawal amount: ");

        // Prevent withdrawing more than available balance - no overdraft
        if (amount > balance)
        {
            Console.WriteLine("Error: Insufficient funds. You cannot withdraw more than your balance.");
            Console.WriteLine($"Current balance: {balance:F2}");
            return; // cancel this transaction and go back to menu
        }

        balance -= amount; // withdraw reduces balance
        Console.WriteLine($"Withdrawal successful. New balance: {balance:F2}");
    }

    static void BalanceInquiry()
    {
        // Just showing balance, not modifying anything
        Console.WriteLine($"Current balance: {balance:F2}");
    }

    static double ReadPositiveAmount(string prompt)
    {
        // One place to validate amounts so Deposit/Withdraw stay clean
        while (true)
        {
            Console.Write(prompt);

            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                return amount;

            Console.WriteLine("Invalid amount. Enter a positive number.");
        }
    }
}
