using System;

    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St.", "Anytown", "CA", "USA");
            Customer customer1 = new Customer("John Doe", address1);
            Product product1 = new Product("iPhone 13", "APL-1234", 1099.99, 2);
            Product product2 = new Product("AirPods Pro", "APL-5678", 250, 1);
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            Console.WriteLine("\nOrder 1 Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine("Order 1 Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine("Order 1 Total Price: $" + order1.GetTotalPrice());

            Address address2 = new Address("456 Main St.", "Anytown", "CA", "Canada");
            Customer customer2 = new Customer("Jane Doe", address2);
            Product product3 = new Product("iPad Air", "APL-9012", 649.99, 3);
            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            Console.WriteLine("\n\nOrder 2 Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine("Order 2 Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine("Order 2 Total Price: $" + order2.GetTotalPrice() + "\n");
        }
    } 