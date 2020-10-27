using System;
using System.Collections.Generic;

//The code is all wrapped in a class so it can be reused and put into a diffirent context 
class AddressProgram
{
    //All of the addresses are stored here
    AddressBook book;

    //Constructor
    public AddressProgram()
    {
        book = new AddressBook();
    }

    //For this excercise, I'm using a simple CLI. In a real world context, a proper GUI would be ideal.
    void startMenu()
    {
        Console.WriteLine("Start Menu");
        Console.WriteLine("Type a letter to continue");
        Console.WriteLine("=========================");
        Console.WriteLine("(A) - Add an Address");
        Console.WriteLine("(D) - Delete an Address");
        Console.WriteLine("(L) - List All Addresses");
        Console.WriteLine("(S) - Save current Addresses");
        Console.WriteLine("(W) - Load Addresses from Txt");
        Console.WriteLine("=========================");
        Console.WriteLine("(Q) - Quit Program");
    }

    static void Main(string[] args)
    {
        string selection = String.Empty;
        AddressProgram program = new AddressProgram();
        // Display the number of command line arguments and choices
        program.startMenu();

        //Program stays running until Q is entered which exits the program
        while (!selection.ToUpper().Equals("Q"))
        {
            Console.WriteLine("Selection : ");
            selection = Console.ReadLine();
            program.performAction(selection);
        }
    }

    void performAction(string selection)
    {
        //Intialising values for CLI Use
        string firstName = String.Empty;
        string otherName = String.Empty;
        string emailAddress = String.Empty;

        string phoneNumberString = String.Empty;
        string phoneNumber = String.Empty;
        string street = String.Empty;
        string town = String.Empty;
        string country = String.Empty;
        

        switch (selection.ToUpper())
        {
            case "A":
                //Clears the console 
                Console.Clear();
                //First Name
                Console.WriteLine("Enter First Name: ");
                firstName = Console.ReadLine();
                //Other Name
                Console.WriteLine("Enter Other Name (If none, continue): ");
                otherName = Console.ReadLine();
                //Email Address
                Console.WriteLine("Enter Email Address");
                emailAddress = Console.ReadLine();
                //Phone Number (NEEDS AREA CODE IN FUTURE)
                Console.WriteLine("Enter Phone Number");
                phoneNumber = Console.ReadLine();
                //ADDRESS VALUES
                //Street
                Console.WriteLine("Address Details : ");
                Console.WriteLine("Enter Street Name");
                street = Console.ReadLine();
                Console.WriteLine("Enter Town Name");
                town = Console.ReadLine();
                Console.WriteLine("Enter Country Name");
                country = Console.ReadLine();

                //Adds the address that has been created
                if (book.add(firstName,otherName,emailAddress,phoneNumber,street,town,country))
                {
                    Console.WriteLine("Address has been added");
                }
                else //This else statement will display if there is an identical address.
                {
                    Console.WriteLine("An address is in the list Already.", firstName);
                }
                
                break;
            case "D":
                Console.WriteLine("Enter Name to Delete: ");
                firstName = Console.ReadLine();
                if (book.delete(firstName))
                {
                    Console.WriteLine("Address successfully removed");
                }
                else
                {
                    Console.WriteLine("Address for {0} could not be found.", firstName);
                }
                break;
            case "L":
                if (book.isEmpty())
                {
                    Console.WriteLine("There are no entries.");
                }
                else
                {
                    Console.WriteLine("Address Table:");
                    book.list();
                }
                break;
            case "S":
                book.save();
                break;
            case "W":
                book.load();
                break;
           
        }
    }
}