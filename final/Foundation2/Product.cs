using System;

    class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetPrice()
        {
            return this.price * this.quantity;
        }
        public string GetName()
        {
            return this.name;
        }

        public string GetProductId()
        {
            return this.productId;
        }
    }
