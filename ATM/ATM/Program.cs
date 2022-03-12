using ATM.Entities;
using ATM.utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using ATM.DB;


namespace ATM;
    class program
{
    static void Main(string[] args)
    {
        // Start DB first
        var success = DB.DB.InitDB();
        if(success)
        {
            Console.WriteLine("Connected...");
        } else
        {
            SystemFailure();
        }

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
                SystemFailure();
                break;
        }

        Console.ReadKey();

    }

    public static bool Login()
    {
        Console.WriteLine($"Login...\n");
        Console.WriteLine("Enter Username.");
        string cardNumber = Console.ReadLine();
        Console.WriteLine("Enter 4 digit pin.");
        string pin = Console.ReadLine();
        return true;
    }

    public static void Signup()
    {
        string username;
        string encryptedPin;
        decimal balance = 0.0m;
        Console.WriteLine("Lets sign you up!");
        Console.WriteLine("Enter a username with a mix of numbers and letters and is 15 characters or less.");
        while (true)
        {
            username = Console.ReadLine();
            if (Validations.isValidUsername(username))
            {
                break;
            }
            Console.WriteLine("Invalid username please try again...");
        }

        Console.WriteLine("Enter a 4 digit pin.");
        while (true)
        {
            string pin = Console.ReadLine();
            if (Validations.isValidBankPin(pin))
            {
                encryptedPin = Validations.EncryptBankPin(pin);
                break;
            }
            Console.WriteLine("Invalid pin please try again...");
        }
        Guid accountNumber = Guid.NewGuid();
        DB.DB.PayLoad payload = DB.DB.CreateAccount(accountNumber, username, encryptedPin);
        
        Console.WriteLine("Here's your card number for logging in...\n");
        Console.WriteLine($"{payload.Data}");

        if(payload.Result != 0)
        {
            SystemFailure();
        }
        Login();
    }

    static void ImitateLoading()
    {
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

    static void SystemFailure()
    {
        Console.WriteLine("An error occurred please try again. Shutting down...");
        Thread.Sleep(5000);
        System.Environment.Exit(0);
    }
}