using System;
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
