using System;   
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