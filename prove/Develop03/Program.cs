using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture object
        var scripture = new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Display the complete scripture
        DisplayScripture(scripture);

        Console.WriteLine("Press Enter to hide random words or type 'quit' to exit.");

        while (true)
        {
            var input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            // Hide random words in the scripture
            scripture.HideRandomWords();

            // Display the scripture with hidden words
            DisplayScripture(scripture);

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words in the scripture are hidden. Exiting.");
                break;
            }

            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
        }
    }

    static void DisplayScripture(Scripture scripture)
    {
    Console.Cle
        Console.WriteLine(scripture.GetDisplayText());
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        Random rand = new Random();
        int wordsToHide = rand.Next(1, _words.Count / 2);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = rand.Next(0, _words.Count);
            _words[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()}\n\n";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText;
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
            return new string('_', _text.Length);
        else
            return _text;
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}


