using System;

public enum Priority
{
    Low,
    Medium,
    High
}

class Program
{
    static void Main(string[] args)
    {
        // Main menu loop: keeps the program running until user selects Exit.
        bool exitMainWindow = false;

        while (!exitMainWindow)
        {
            ShowMainMenu();
            string mainChoice = Console.ReadLine() ?? "";

            // Switch is clean for menu navigation since options are fixed.
            switch (mainChoice)
            {
                case "1":
                    RunTaskManagementSystem();
                    break;

                case "2":
                    RunStudentGradeManagementSystem();
                    break;

                case "3":
                    RunBankingSystem();
                    break;

                case "4":
                    exitMainWindow = true;
                    ExitSystem();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1-4.");
                    break;
            }
        }
    }

    static void ShowMainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n==========================================================");
        Console.WriteLine("     List of Projects     ");
        Console.WriteLine("==========================================================");
        Console.WriteLine("1. Task Management System");
        Console.WriteLine("2. Student Grading System");
        Console.WriteLine("3. Banking System");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");
        Console.ResetColor();
    }

    static void RunTaskManagementSystem()
    {
        // Load tasks when entering this module so old tasks show up.
        TaskItem.LoadTasksFromFile();

        bool exitTMS = false;

        while (!exitTMS)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n******************************");
            Console.WriteLine("     TASK MANAGEMENT SYSTEM     ");
            Console.WriteLine("******************************");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Filter Tasks by Priority");
            Console.WriteLine("6. Sort Tasks by Due Date");
            Console.WriteLine("7. Save Task to File");
            Console.WriteLine("8. Back to Main Menu");
            Console.Write("Choose an option: ");
            Console.ResetColor();

            string choiceTMS = Console.ReadLine() ?? "";

            switch (choiceTMS)
            {
                case "1":
                    TaskItem.AddTask();
                    break;
                case "2":
                    TaskItem.ViewAllTasks();
                    break;
                case "3":
                    TaskItem.MarkTaskCompleted();
                    break;
                case "4":
                    TaskItem.DeleteTask();
                    break;
                case "5":
                    TaskItem.FilterTasksByPriority();
                    break;
                case "6":
                    TaskItem.SortTasksByDueDate();
                    break;
                case "7":
                    TaskItem.SaveTasksToFile();
                    break;
                case "8":
                    exitTMS = true; // exit only this module
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-8.");
                    break;
            }
        }
    }

    static void RunStudentGradeManagementSystem()
    {
        bool exitGMS = false;

        while (!exitGMS)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n******************************");
            Console.WriteLine("     Student Grade Management System     ");
            Console.WriteLine("******************************");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Add Grade to Student");
            Console.WriteLine("4. Calculate Average Grade for Student");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Choose an option: ");
            Console.ResetColor();

            string choiceGMS = Console.ReadLine() ?? "";

            switch (choiceGMS)
            {
                case "1":
                    Student.AddStudent();
                    break;
                case "2":
                    Student.ViewAllStudents();
                    break;
                case "3":
                    Student.AddGradeToStudent();
                    break;
                case "4":
                    Student.CalculateAverageForStudent();
                    break;
                case "5":
                    exitGMS = true; // exit only this module
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-5.");
                    break;
            }
        }
    }

    static void RunBankingSystem()
    {
        // Banking system is implemented in Banking.cs
        BankingSystem.Run();
    }

    static void ExitSystem()
    {
        Console.WriteLine("Exiting the entire system. Goodbye!");
    }
}
