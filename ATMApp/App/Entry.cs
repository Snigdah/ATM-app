using ATMApp.Domain.Interfaces;
using ATMApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.AppScreen
{
    class Entry
    {
        static void Main(string[] args)
        {
            UI.Screen.welcome();

            ATMApp atmApp = new ATMApp();

            atmApp.InitializeData();
            atmApp.CheckUsercardNumAndPassword();
            atmApp.Welcome();

            Utility.PressEnterToContinue();
        }
    }
}
