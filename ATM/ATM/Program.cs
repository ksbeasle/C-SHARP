using ATM.Entities;
using System;
using System.Threading;


namespace ATM;
    class program
{
    static void Main(string[] args)
    {
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
                Login();
                break;
            case "1":
                Console.WriteLine("1");
                break;
            case "signup":
                Console.WriteLine("signup");
                break;
            case "2":
                Console.WriteLine("2");
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
        return true;
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
}