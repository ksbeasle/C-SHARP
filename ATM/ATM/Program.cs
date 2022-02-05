using ATM.Entities;
using ATM.utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;


namespace ATM;
    class program
{
    static void Main(string[] args)
    {
        // Start DB first
        var success = DB.DBConnection.InitDB();
        if(success)
        {
            Console.WriteLine("Connected...");
        } else
        {
            Console.WriteLine("Error.");
        }

        DB.DBConnection.Query("SELECT * FROM ATM.dbo.Test1");
        string title = @"
          _____             _____                    _____          
         /\    \           /\    \                  /\    \         
        /::\    \         /::\    \                /::\____\        
       /::::\    \        \:::\    \              /::::|   |        
      /::::::\    \        \:::\    \            /:::::|   |        
     /:::/\:::\    \        \:::\    \          /::::::|   |        
    /:::/__\:::\    \        \:::\    \        /:::/|::|   |        
   /::::\   \:::\    \       /::::\    \      /:::/ |::|   |        
  /::::::\   \:::\    \     /::::::\    \    /:::/  |::|___|______  
 /:::/\:::\   \:::\    \   /:::/\:::\    \  /:::/   |::::::::\    \ 
/:::/  \:::\   \:::\____\ /:::/  \:::\____\/:::/    |:::::::::\____\
\::/    \:::\  /:::/    //:::/    \::/    /\::/    / ~~~~~/:::/    /
 \/____/ \:::\/:::/    //:::/    / \/____/  \/____/      /:::/    / 
          \::::::/    //:::/    /                       /:::/    /  
           \::::/    //:::/    /                       /:::/    /   
           /:::/    / \::/    /                       /:::/    /    
          /:::/    /   \/____/                       /:::/    /     
         /:::/    /                                 /:::/    /      
        /:::/    /                                 /:::/    /       
        \::/    /                                  \::/    /        
         \/____/                                    \/____/         
                                                                    
";
        Console.WriteLine(title);

        Guid guid = Guid.NewGuid();
        Console.WriteLine($"BLAH {guid}");

        Console.WriteLine("Welcome to the ATM!");
        ImitateLoading();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine($"\n");
        Console.WriteLine("Options:");
        Console.WriteLine($"1. Login \n2. Signup");

        string? userSelection = Console.ReadLine();

        switch (userSelection.ToLower())
        {
            case "login":
            case "1":
                Login();
                break;
            case "signup":
            case "2":
                Signup();
                break;
            default:
                Console.WriteLine("An error occurred please try again. Shutting down...");
                Thread.Sleep(5000);
                System.Environment.Exit(0);
                break;
        }

        Console.ReadKey();

    }

    public static bool Login()
    {
        Console.WriteLine("Enter Username.");
        string cardNumber = Console.ReadLine();
        Console.WriteLine("Enter 4 digit pin.");
        string pin = Console.ReadLine();
        return true;
    }

    public static bool Signup()
    {
        Console.WriteLine("Lets sign you up!");
        Console.WriteLine("Enter a username with a mix of numbers and letters and is 15 characters or less.");
        while (true)
        {
            string username = Console.ReadLine();
            if (Validations.isValidUsername(username))
            {
                break;
            }
            Console.WriteLine("Invalid username please try again...");
        }

        Console.WriteLine("Enter a 4 digit pin.");
        while(true)
        {
            string pin = Console.ReadLine();
            if (Validations.isValidBankPin(pin))
            {
                break;
            }
            Console.WriteLine("Invalid pin please try again...");
        }

        Console.WriteLine("Account created.");
        //Call Login() here
        return true;
    }

    static void ImitateLoading()
    {
          /*  while (dataReader.Read())
            {
                Object[] values = new Object[dataReader.FieldCount];
                int numOfColumns = dataReader.GetValues(values);
                Console.WriteLine("Retrieved {0} columns", numOfColumns);
                Console.WriteLine("VALLLL {0}", values);
                foreach(Object obj in values)
                {
                    Console.WriteLine("OBJECT BRO {0}", obj);
                }
            }*/
        var counter = 0;
        for (int i = 0; i < 50; i++)
        {
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            counter++;
            Thread.Sleep(100);
        }
        
    }
}