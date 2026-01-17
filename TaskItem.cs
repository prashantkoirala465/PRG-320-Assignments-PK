using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class TaskItem
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

    static List<TaskItem> tasks = new List<TaskItem>();
    static string filePath = "tasks.txt";

    public TaskItem() { }

    public TaskItem(string title, string description, Priority priority, DateTime dueDate)
    {
        Title = title;
        Description = description;
        Priority = priority;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public void Display()
    {
        // This is for console output only (so we can use colors if we want).
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Title: ");
        Console.ResetColor();
        Console.Write($"{Title} | ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Description: ");
        Console.ResetColor();
        Console.Write($"{Description} | ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Priority: ");
        Console.ResetColor();
        Console.Write($"{Priority} | ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Due Date: ");
        Console.ResetColor();
        Console.Write($"{DueDate:yyyy-MM-dd} | ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Status: ");
        Console.ResetColor();
        Console.WriteLine(IsCompleted ? "Completed" : "Pending");
    }

    public string ToFileLine()
    {
        // File format is simple and consistent so Load can parse easily.
        return $"{Title}|{Description}|{Priority}|{DueDate:yyyy-MM-dd}|{(IsCompleted ? "Completed" : "Pending")}";
    }

    public static void AddTask()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        Console.Write("Enter task description: ");
        string description = Console.ReadLine() ?? "";

        Priority priority = GetValidPriority();
        DateTime dueDate = GetValidDate("Enter due date (yyyy-MM-dd): ");

        tasks.Add(new TaskItem(title.Trim(), description.Trim(), priority, dueDate));
        Console.WriteLine("Task added successfully.");
    }

    public static void ViewAllTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("\nAll Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            tasks[i].Display();
        }
    }

    public static void MarkTaskCompleted()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        ViewAllTasks();
        int index = ReadIndex("Enter the task number to mark as completed: ", tasks.Count);
        tasks[index].IsCompleted = true;

        Console.WriteLine("Task marked as completed.");
    }

    public static void DeleteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        ViewAllTasks();
        int index = ReadIndex("Enter the task number to delete: ", tasks.Count);
        tasks.RemoveAt(index);

        Console.WriteLine("Task deleted.");
    }

    public static void FilterTasksByPriority()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Priority priority = GetValidPriority();
        var filtered = tasks.Where(t => t.Priority == priority).ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine($"No tasks with {priority} priority.");
            return;
        }

        Console.WriteLine($"\nTasks with {priority} priority:");
        for (int i = 0; i < filtered.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            filtered[i].Display();
        }
    }

    public static void SortTasksByDueDate()
    {
        tasks = tasks.OrderBy(t => t.DueDate).ToList();
        Console.WriteLine("Tasks sorted by due date.");
        ViewAllTasks();
    }

    public static Priority GetValidPriority()
    {
        while (true)
        {
            Console.Write("Enter priority (Low, Medium, High): ");
            string input = Console.ReadLine() ?? "";

            if (Enum.TryParse(input, true, out Priority priority))
                return priority;

            Console.WriteLine("Invalid priority. Please enter Low, Medium, or High.");
        }
    }

    public static DateTime GetValidDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (DateTime.TryParse(input, out DateTime date))
                return date;

            Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
        }
    }

    public static void LoadTasksFromFile()
    {
        tasks.Clear(); // prevents duplicate tasks when re-entering module

        if (!File.Exists(filePath))
            return;

        foreach (string line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split('|');
            if (parts.Length != 5) continue;

            string title = parts[0].Trim();
            string description = parts[1].Trim();

            if (!Enum.TryParse(parts[2].Trim(), true, out Priority priority))
                continue;

            if (!DateTime.TryParse(parts[3].Trim(), out DateTime dueDate))
                continue;

            bool isCompleted = parts[4].Trim().Equals("Completed", StringComparison.OrdinalIgnoreCase);

            TaskItem task = new TaskItem(title, description, priority, dueDate);
            task.IsCompleted = isCompleted;
            tasks.Add(task);
        }
    }

    public static void SaveTasksToFile()
    {
        // We write clean file lines, not console output.
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (TaskItem task in tasks)
            {
                writer.WriteLine(task.ToFileLine());
            }
        }

        Console.WriteLine("Tasks saved to file.");
    }

    static int ReadIndex(string prompt, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int index) && index >= 1 && index <= max)
                return index - 1;

            Console.WriteLine($"Invalid choice. Enter a number between 1 and {max}.");
        }
    }
}
