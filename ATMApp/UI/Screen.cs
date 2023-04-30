using ATMApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.UI
{
    public static class Screen
    {
       internal static void welcome()
       {
            //Clear console, set title and color
            Console.Clear();
            Console.Title = "My ATM App";
            Console.ForegroundColor = ConsoleColor.Green;

            //set wellcome message
            Console.WriteLine("\n\n-----------------Welcome to my App----------------\n\n");
            Console.WriteLine("Please insert your ATM Card");
            Console.WriteLine("Node: Actual ATM machine will accept and validate");
            Console.WriteLine("A physical ATM card, read the card number and validate it");

            Utility.PressEnterToContinue();
       }

       internal static UserAccount UserLoginForm()
       {
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount.CardNumber = Validator.Convert<long>("Your card Number");
            tempUserAccount.CardPin = Convert.ToInt32(Utility.GetSecretInput("Enter your card PIN"));

            return tempUserAccount;
       }
       
       internal static void LoginProgress()
       {
            Console.WriteLine("\nChecking card number and PIN... ");
            Utility.PrintDotAnimation();    
       } 


       internal static void PrintLockScreen()
       {
            Console.Clear();
            Utility.PrintMessage("Your account is locked. Please go to the nearest branch." +
                "to unclock your account. Thank You", false);
            Utility.PressEnterToContinue();
            Environment.Exit(1);
        }
    }
}
