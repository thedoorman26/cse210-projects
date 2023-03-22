using System;

    class Order
    {
        private Customer customer;
        private Product[] products;
        private int productCount;

        public Order(Customer customer)
        {
            this.customer = customer;
            this.products = new Product[10];
            this.productCount = 0;
        }

        public void AddProduct(Product product)
        {
            this.products[this.productCount++] = product;
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (Product product in this.products)
            {
                if (product == null)
                {
                    break;
                }
                totalPrice += product.GetPrice();
            }
            if (this.customer.IsInUSA())
            {
                totalPrice += 5;
            }
            else
            {
                totalPrice += 35;
            }
            return totalPrice;
        }

        public string GetPackingLabel()
        {
            string packingLabel = "Order for " + this.customer.GetName() + ":\n";
            foreach (Product product in this.products)
            {
                if (product == null)
                {
                    break;
                }
                packingLabel += product.GetName() + " (" + product.GetProductId() + ")\n";
            }
            return packingLabel;
        }

        public string GetShippingLabel()
        {
            string shippingLabel = "Shipping label for " + this.customer.GetName() + ":\n";
            shippingLabel += this.customer.GetAddress().ToString() + "\n";
            return shippingLabel;
        }
    }