using ATMApp.Domain.Entities;
using ATMApp.Domain.Interfaces;
using ATMApp.UI;
using System;

namespace ATMApp
{
    public class ATMApp : IUserLogin            
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount
                {
                    Id = 1,
                    FullName = "Snigdho",
                    AccountNumber = 123456,
                    CardNumber = 321321,
                    CardPin = 120123,
                    AccountBalance = 5000.00m,
                    IsLocked = false,
                },
                new UserAccount
                {
                    Id = 2,
                    FullName = "Tania",
                    AccountNumber = 1234560,
                    CardNumber = 321210,
                    CardPin = 120230,
                    AccountBalance = 50000.00m,
                    IsLocked = false,
                },
                new UserAccount
                {
                    Id = 3,
                    FullName = "Sayed",
                    AccountNumber = 1234561,
                    CardNumber = 323211,
                    CardPin = 123890,
                    AccountBalance = 50001.00m,
                    IsLocked = true,
                }
            };

        }

        public void CheckUsercardNumAndPassword()
        {
           bool isCorrectLogin = false;


            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = Screen.UserLoginForm();
                Screen.LoginProgress();
                foreach (UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if (inputAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        selectedAccount.TotalLogin++;

                        if (inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;

                            if (selectedAccount.IsLocked || selectedAccount.TotalLogin > 3)
                            {
                                Screen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                    if (isCorrectLogin == false)
                    {
                        Utility.PrintMessage("\nInvalid card number or PIN.", false);
                        selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                        if (selectedAccount.IsLocked)
                        {
                            Screen.PrintLockScreen();
                        }
                    }
                    Console.Clear();
                }
            }


            
        }

        public void Welcome()
        {
            Console.WriteLine($"WelCome back, {selectedAccount.FullName}");
        }
    }
}
