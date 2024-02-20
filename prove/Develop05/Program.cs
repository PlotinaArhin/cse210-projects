using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// Base class for goals
[Serializable]
public abstract class Goal
{
    protected string name;
    protected bool completed;
    protected int points;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
        completed = false;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Goal: {name}, Points: {points}, Completed: {completed}");
    }

    public virtual void MarkAsCompleted()
    {
        completed = true;
    }

    public virtual void ReceivePoints()
    {
        if (!completed)
        {
            Console.WriteLine($"Points received for goal: {name}, Points: {points}");
        }
        else
        {
            Console.WriteLine($"Goal {name} is already completed. No points received.");
        }
    }

    // Marking the 'completed' field as virtual to ensure proper serialization in derived classes
    // Note: This assumes all derived classes use the 'completed' field, adjust as needed
    public virtual bool Completed => completed;
}

// Derived class for eternal goals
[Serializable]
public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points)
    {
    }

    public override void MarkAsCompleted()
    {
        Console.WriteLine("Eternal goals cannot be marked as completed.");
    }
}

// Derived class for checklist goals
[Serializable]
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;

    public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
    {
        this.targetCount = targetCount;
        currentCount = 0;
    }

    public void IncrementCount()
    {
        currentCount++;
        if (currentCount >= targetCount)
        {
            MarkAsCompleted();
            ReceivePoints();
        }
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Goal: {name}, Points: {points}, Current Count: {currentCount}/{targetCount}, Completed: {completed}");
    }
}

// Class to manage user data
[Serializable]
public class UserData
{
    public List<Goal> goals;
    public int score;

    public UserData()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void SaveUserData(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, this);
                Console.WriteLine("User data saved successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving user data: {e.Message}");
        }
    }

    public static UserData LoadUserData(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (UserData)formatter.Deserialize(fs);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading user data: {e.Message}");
            return null;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        ChecklistGoal workoutGoal = new ChecklistGoal("Workout", 50, 5);
        EternalGoal readBookGoal = new EternalGoal("Read a book", 30);

        workoutGoal.IncrementCount();

        // Display goals
        workoutGoal.DisplayDetails();
        readBookGoal.DisplayDetails();

        // Save and load user data
        UserData user = new UserData();
        user.goals.Add(workoutGoal);
        user.goals.Add(readBookGoal);
        user.score = 100;

        user.SaveUserData("userData.dat");

        UserData loadedUser = UserData.LoadUserData("userData.dat");
        if (loadedUser != null)
        {
            Console.WriteLine($"Loaded user score: {loadedUser.score}");
            Console.WriteLine("Loaded user goals:");
            foreach (var goal in loadedUser.goals)
            {
                goal.DisplayDetails();
            }
        }
    }
}
