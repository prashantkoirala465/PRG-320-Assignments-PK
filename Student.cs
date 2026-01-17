using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; } = "";
    public List<double> Grades { get; set; } = new List<double>();

    // Keeping a single list for this console app session.
    static List<Student> students = new List<Student>();

    public Student() { }

    public Student(string name)
    {
        Name = name;
    }

    public double CalculateAverage()
    {
        // Avoid division by zero when no grades exist.
        if (Grades.Count == 0) return 0.0;

        double sum = 0;
        foreach (double grade in Grades)
        {
            sum += grade;
        }

        return sum / Grades.Count;
    }

    public static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name. Please enter a valid student name.");
            return;
        }

        students.Add(new Student(name.Trim()));
        Console.WriteLine($"Student '{name.Trim()}' added successfully.");
    }

    public static void ViewAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students in the system.");
            return;
        }

        Console.WriteLine("\nList of Students:");
        for (int i = 0; i < students.Count; i++)
        {
            string gradesText = students[i].Grades.Count == 0
                ? "No grades"
                : string.Join(", ", students[i].Grades);

            Console.WriteLine($"{i + 1}. {students[i].Name} (Grades: {gradesText})");
        }
    }

    public static void AddGradeToStudent()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available. Add a student first.");
            return;
        }

        ViewAllStudents();
        Console.Write("Enter the student number to add grade: ");
        string input = Console.ReadLine() ?? "";

        if (!int.TryParse(input, out int index) || index < 1 || index > students.Count)
        {
            Console.WriteLine("Invalid student number.");
            return;
        }

        // Grade validation is important so averages stay meaningful.
        double grade = GetValidGrade("Enter grade (0-100): ");
        students[index - 1].Grades.Add(grade);

        Console.WriteLine($"Grade {grade} added to {students[index - 1].Name}.");
    }

    public static void CalculateAverageForStudent()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available. Add a student first.");
            return;
        }

        ViewAllStudents();
        Console.Write("Enter the student number to calculate average: ");
        string input = Console.ReadLine() ?? "";

        if (!int.TryParse(input, out int index) || index < 1 || index > students.Count)
        {
            Console.WriteLine("Invalid student number.");
            return;
        }

        double average = students[index - 1].CalculateAverage();
        Console.WriteLine($"Average grade for {students[index - 1].Name}: {average:F2}");
    }

    public static double GetValidGrade(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (double.TryParse(input, out double grade) && grade >= 0 && grade <= 100)
                return grade;

            Console.WriteLine("Invalid grade. Please enter a number between 0 and 100.");
        }
    }
}
