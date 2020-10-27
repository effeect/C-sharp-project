using System;

// This file is a simple base class for any address within the address book
class Address{
    //Name variables, mid name placeholder
    public string firstName = String.Empty;
    public string otherName = String.Empty;
    public string emailAddress = String.Empty;

    //The phone number will have to be converted to a string at some point, if the address book is international, the phone number will require area codes and sometimes dashes
    public int areaCode = 44; //UK Area Code
    public string phoneNumber;

    //Can be put into object in future
    public string street;
    public string town;
    public string country;


    //Constructor
    public Address(string name,string otherName,string emailAddress, string phoneNumber, string street , string town , string country)
    {
        //Names
        this.firstName = name;
        this.otherName = otherName;
        this.emailAddress = emailAddress;

        //Phone Number Info
        this.phoneNumber = phoneNumber;
        this.street = street;
        this.town = town;
        this.country = country;
    }
}