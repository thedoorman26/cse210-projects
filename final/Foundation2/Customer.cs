using System;

class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public bool IsInUSA()
        {
            return this.address.IsInUSA();
        }

        public string GetName()
        {
            return this.name;
        }

        public Address GetAddress()
        {
            return this.address;
        }
    }