using System

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("1. Add new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            Console.WriteLine();
        }
    }
}