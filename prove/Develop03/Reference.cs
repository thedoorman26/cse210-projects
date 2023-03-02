using System;
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