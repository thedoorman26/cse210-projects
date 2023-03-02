using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the scripture reference in the format 'Book Chapter:Verse' (e.g. John 3:16 or Proverbs 3:5-6). For books with multiple words in the name, please hyphenate them (e.g. 1-Nephi):");
            string referenceInput = Console.ReadLine();

            Console.WriteLine("Enter the text of the scripture:");
            string scriptureText = Console.ReadLine();

            Reference scriptureReference = new Reference(referenceInput);
            Scripture scripture = new Scripture(scriptureReference, scriptureText);

            scripture.Display();

            while (scripture.WordsHidden < scripture.Words.Count)
            {
                Console.WriteLine("\nPress enter to hide more words or type 'quit' to end:");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords();
                scripture.Display();
            }

            Console.WriteLine("\nAll words hidden. Goodbye!");
        }
    }




