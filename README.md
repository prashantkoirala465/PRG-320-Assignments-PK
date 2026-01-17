# PRG-320 C# Programming - Course Assignments

This repository contains my assignments for **PRG-320: C# Programming** course taught by Professor Rozer Shrestha.

## What's Inside

The project combines three console applications into one main menu system:

### 1. Task Management System
A simple to-do app where you can add tasks, set priorities (Low/Medium/High), mark them complete, and save everything to a file. You can also filter by priority or sort by due date.

### 2. Student Grade Management
Lets you add students and their grades, then calculate averages. Nothing fancy, just basic grade tracking.

### 3. Banking System
A basic banking simulator with PIN login (default: 1234). You can deposit, withdraw, and check balance. It won't let you overdraft.

## How to Run

Make sure you have .NET 10.0 installed, then:

```bash
dotnet run
```

You'll see a main menu where you can pick which system to use. Each one has its own submenu.

## Project Structure

- `Program.cs` - Main entry point and menu system
- `TaskItem.cs` - Task management logic
- `Student.cs` - Student grading system
- `Banking.cs` - Banking operations
- `Week2_Assignment/week2_assignment.cs` - Earlier banking assignment (week 2)

## Notes

The task system saves to `tasks.txt` in the same directory. The banking PIN is hardcoded to 1234 (don't use this in real life obviously).

---

**Course:** PRG-320: C# Programming  
**Instructor:** Rozer Shrestha  
**Student:** Prashant Koirala
