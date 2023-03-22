using System;

    class Address
    {
        private string streetAddress;
        private string city;
        private string stateOrProvince;
        private string country;

        public Address(string streetAddress, string city, string stateOrProvince, string country)
        {
            this.streetAddress = streetAddress;
            this.city = city;
            this.stateOrProvince = stateOrProvince;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return this.country == "USA";
        }

        public override string ToString()
        {
            return this.streetAddress + "\n" + this.city + ", " + this.stateOrProvince + " " + this.country;
        }
    }
