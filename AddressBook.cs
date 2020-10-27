using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.IO;

class AddressBook
{
    //Storage of Addresses, refering to ADDRESS.cs
    List<Address> addressList;

    public AddressBook()
    {
        addressList = new List<Address>();
    }

    //Function that adds an object to the address list
    public bool add(string name, string otherName, string emailAddress, string phoneNumber, string street, string town, string country)
    {
        Address addr = new Address(name,otherName,emailAddress,phoneNumber,street,town,country);
        Address result = find(name);

        if (result == null)
        {
            addressList.Add(addr);
            return true;
        }
        else { return false; }
    }
    
    //This function removes an object from the address list
    public bool delete(string name)
    {
        Address addr = find(name);

        if (addr != null)
        {
            addressList.Remove(addr);
            return true;
        }
        else
        {
            return false;
        }
    }

    //Search via First Name REFACTOR NEEDED
    public Address find(string name)
    {
        Address addr = addressList.Find((a) => a.firstName == name);
        return addr;
    }


    //Prints out list, would use external library to make the listing neat. Would use https://www.nuget.org/packages/ConsoleTables/
    public void list()
    {
        Console.WriteLine($"{"FIRST NAME",20} {"OTHER NAME",20} {"EMAIL",20} {"PHONE NUMBER",20} {"STREET",20} {"TOWN",20} {"COUNTRY",20}");
        foreach (Address a in addressList)
        {
            Console.WriteLine($"{a.firstName,20} {a.otherName,20} {a.emailAddress,20} {a.phoneNumber,20} {a.street,20} {a.town,20} {a.country,20}");
        }
    }

    public bool isEmpty()
    {
        return (addressList.Count == 0);
    }

    //Saves the address book into a text file
    public void save()
    {
        string temp = String.Empty;

        //For loop that will write to a txt file
        foreach (Address a in addressList)
        {
            temp += $"\n{a.firstName}\n {a.otherName}\n {a.emailAddress}\n {a.phoneNumber}\n {a.street}\n {a.town}\n {a.country}";
        }

        System.IO.File.WriteAllText("SaveLists.txt", temp);
    }

    //Line Reading is and will display double but the files can be saved and loaded
    public void load()
    {
        var firstNames = new List<string>();
        var otherNames = new List<string>();
        var emailAddresses = new List<string>();
        var phoneNumbers = new List<string>();
        var streets = new List<string>();
        var towns = new List<string>();
        var countrys = new List<string>();

        var lines = File.ReadLines("SaveLists.txt");
        int counter = 0;
        foreach (var line in lines)
        {
            switch (counter)
            {
                case 0:
                    firstNames.Add(line);
                    break;
                case 1:
                    otherNames.Add(line);
                    break;
                case 2:
                    emailAddresses.Add(line);
                    break;
                case 3:
                    phoneNumbers.Add(line);
                    break;
                case 4:
                    streets.Add(line);
                    break;
                case 5:
                    towns.Add(line);
                    break;
                case 6:
                    countrys.Add(line);
                    break;
            }
            if(counter > 6)
            {
                counter = -1;
            }
            if (counter < 6)
            {
                counter += 1;
            }
            Console.WriteLine(line);
        }

        Console.WriteLine(firstNames.Count());

        for(int i = 0; i < firstNames.Count(); i++)
        {
            Address addr = new Address(firstNames[i], otherNames[i], emailAddresses[i], phoneNumbers[i], streets[i], towns[i], countrys[i]);
            addressList.Add(addr);
            Console.WriteLine(i);
        }
     

    }

    public void saveTest()
    {
        foreach (Address a in addressList)
        {
            Console.WriteLine($"\n{a.firstName,20} {a.otherName,20} {a.emailAddress,20} {a.phoneNumber,20} {a.street,20} {a.town,20} {a.country,20}");
        }
        string json = JsonSerializer.Serialize(addressList);
        //var json = JsonSerializer.Serialize(addressList);
        System.IO.File.WriteAllText("lists.json", json);
    }

    // https://stackoverflow.com/questions/4266875/how-to-quickly-save-load-class-instance-to-file
    //public void Save()
    //{
    //    List<Address> listofa = addressList;
    //    Type myClassType = Type.GetType("Address");
    //    string path = "addressBook.xml";
    //    FileStream outFile = File.Create(path);
    //    XmlSerializer formatter = new XmlSerializer(myClassType);
    //    formatter.Serialize(outFile, listofa);
    //}
    //public List<Address> Load()
    //{
    //    Type myClassType = Type.GetType("Address");
    //    string file = "addressBook.xml";
    //    List<Address> listofa = new List<Address>();
    //    XmlSerializer formatter = new XmlSerializer(myClassType);
    //    FileStream aFile = new FileStream(file, FileMode.Open);
    //    byte[] buffer = new byte[aFile.Length];
    //    aFile.Read(buffer, 0, (int)aFile.Length);
    //    MemoryStream stream = new MemoryStream(buffer);
    //    return (List<Address>)formatter.Deserialize(stream);
    //}


}

