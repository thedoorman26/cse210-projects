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

    class Scripture
    {
        private Reference reference;
        private string text;
        private List<Word> words;
        private int wordsHidden;

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            this.text = text;
            this.words = new List<Word>();

            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                this.words.Add(new Word(word));
            }
        }

        public int WordsHidden
        {
            get { return wordsHidden; }
        }

        public List<Word> Words
        {
            get { return words; }
        }

        public void HideRandomWords()
        {
            Random random = new Random();
            int index = random.Next(0, words.Count);

            while (words[index].IsHidden)
            {
                index = random.Next(0, words.Count);
            }

            words[index].Hide();
            wordsHidden++;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(reference.ToString());

            foreach (Word word in words)
            {
                if (word.IsHidden)
                {
                    Console.Write("____ ");
                }
                else
                {
                    Console.Write(word.Text + " ");
                }
            }

            Console.WriteLine();
        }
    }

    class Word
    {
        private string text;
        private bool isHidden;

        public Word(string text)
        {
            this.text = text;
            this.isHidden = false;
        }

        public string Text
        {
            get { return text; }
        }

        public bool IsHidden
        {
            get { return isHidden; }
        }

        public void Hide()
        {
            isHidden = true;
        }
    }

    class Reference
    {
        private string book;
        private int chapter;
        private int startVerse;
        private int endVerse;

        public Reference(string referenceInput)
        {
            string[] referenceParts = referenceInput.Split(' ');
            book = referenceParts[0];
            string[] chapterAndVerse = referenceParts[1].Split(':');
            chapter = int.Parse(chapterAndVerse[0]);

            if (chapterAndVerse[1].Contains("-"))
            {
                string[] startAndEnd = chapterAndVerse[1].Split('-');
                startVerse = int.Parse(startAndEnd[0]);
                endVerse = int.Parse(startAndEnd[1]);
            }
            else
            {
                startVerse = int.Parse(chapterAndVerse[1]);
                endVerse = startVerse;
            }
        }

        public override string ToString()
        {
            if (startVerse == endVerse)
            {
                return book + " " + chapter + ":" + startVerse;
            }
            else
            {
                return book + " " + chapter + ":" + startVerse + "-" + endVerse;
            }
        }
    }