using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_promptText}\nResponse: {_entryText}\n";
    }

    public string ToCsvString()
    {
        return $"{_date},{_promptText},{_entryText}";
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
        // Add your own prompts here
    };

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToCsvString());
            }
        }

        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear();

            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                        AddEntry(loadedEntry);
                    }
                }
            }

            Console.WriteLine("Journal loaded from file.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Selecting a random prompt...");
                    string randomPrompt = journal.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    Entry newEntry = new Entry(DateTime.Now.ToString(), randomPrompt, response);
                    journal.AddEntry(newEntry);
                    break;

                case 2:
                    Console.WriteLine("Displaying the journal...\n");
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case 4:
                    Console.Write("Enter a filename to load the journal: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case 5:
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
