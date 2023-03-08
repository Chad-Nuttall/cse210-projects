using System;

class Journal
{
    private JournalEntry[] entries;
    private int count;

    public Journal()
    {
        entries = new JournalEntry[10];
        count = 0;
    }

    public void AddEntry()
    {
        Random random = new Random();
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        JournalEntry entry = new JournalEntry(DateTime.Now, prompt, response);
        if (count == entries.Length)
        {
            Array.Resize(ref entries, entries.Length * 2);
        }
        entries[count++] = entry;
    }

    public void DisplayEntries()
    {
        for (int i = 0; i < count; i++)
        {
            JournalEntry entry = entries[i];
            Console.WriteLine("{0:yyyy-MM-dd}: {1}\n{2}\n", entry.Date, entry.Prompt, entry.Response);
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < count; i++)
            {
                JournalEntry entry = entries[i];
                writer.WriteLine("{0:yyyy-MM-dd}|{1}|{2}", entry.Date, entry.Prompt, entry.Response);
            }
        }
        Console.WriteLine("Journal saved to {0}\n", fileName);
    }

    public void LoadFromFile()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found: {0}\n", fileName);
            return;
        }
        count = 0;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split('|');
                DateTime date = DateTime.ParseExact(fields[0], "yyyy-MM-dd", null);
                string prompt = fields[1];
                string response = fields[2];
                JournalEntry entry = new JournalEntry(date, prompt, response);
                if (count == entries.Length)
                {
                    Array.Resize(ref entries, entries.Length * 2);
                }
                entries[count++] = entry;
            }
        }
        Console.WriteLine("Journal loaded from {0}\n", fileName);
    }
}

           
