using System;
using System.Collections.Generic;
using System.IO;

namespace POSTerminalMidTerm
{
    class Program
    {
        static List<Item> items = new List<Item>();
        static Receipt receipt = new Receipt();
        static string runAgain = "y";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Amazon Kiosk");

            while (runAgain != "n")
            {
                PrintItemList();
                AddToCart();

                //switch statement select another item

                int addItem = int.Parse(GetUserInput("Would you like to add another item(1/2): "));
                switch (addItem)
                {
                    case 1:
                        runAgain = "y";
                        // addItem method
                        break;
                    case 2:
                        //checkout method
                        runAgain = "n";
                        break;
                    default:
                        GetUserInput("Please select one of the options");
                        break;
                }
            }

            CheckOut();

            // print receipt method
            Console.WriteLine(receipt.ToString());

            //return to the og menu
        }

        public static string GetUserInput(string message)
        {
            string input;
            Console.Write(message);
            input = Console.ReadLine();
            if (input != "")
            {
                return input;
            }
            return GetUserInput(message);
        }

        public static void PrintItemList()
        {
            items = ItemListIO.LoadData();

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i+1}. {items[i].Name} ... {items[i].Price} ");
            }
        }

        public static void AddToCart()
        {
            receipt.AddItemToCart(items[int.Parse(GetUserInput("Please select an item from the list: \n")) - 1]);
        }

        public static void CheckOut()
        {
            int userSelection = int.Parse(GetUserInput("How are you paying for your items today?(1.Credit Card\n/2.Cash\n/3.PayPal\n/4.Check\n)"));

            switch (userSelection)
            {
                case 1:
                    // credit card method
                    CreditPayment payment = new CreditPayment();
                    payment.GetPayment();
                    receipt.PaymentType = payment;
                    break;
                case 2:
                    // cash method
                    CashPayment cash = new CashPayment();
                    cash.GetPayment();
                    if(cash.Input < receipt.Total)
                    {
                        Console.WriteLine("Insufficient funds!");
                        CheckOut();
                        break;
                    }
                    cash.Change = cash.Input - receipt.Total;
                    receipt.PaymentType = cash;
                    break;
                case 3:
                    // paypal method
                    PayPalPayment payPal = new PayPalPayment();
                    payPal.GetPayment();
                    receipt.PaymentType = payPal;
                    break;
                case 4:
                    //check method
                    CheckPayment check = new CheckPayment();
                    check.GetPayment();
                    receipt.PaymentType = check;
                    break;
                default:
                    GetUserInput("Please select a valid payment method");
                    break;
            }
        }

    }
}
