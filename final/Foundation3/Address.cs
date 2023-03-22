using System;

public class Address {
    private string streetAddress;
    private string city;
    private string state;
    private int zipCode;

    public Address(string streetAddress, string city, string state, int zipCode) {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public override string ToString() {
        return $"{streetAddress}, {city}, {state} {zipCode}";
    }
}