using System;
using System.Collections.Generic;
using System.IO;

namespace POSTerminalMidTerm
{
    class Program
    {
        static List<Item> items = new List<Item>();
        static void Main(string[] args)
        {
            PrintItemList();
            // welcome message select item
            int itemSelection = int.Parse(GetUserInput("Welcome to the Amazon Kiosk!\n Please select an item from the list: "));

            // print list

            //switch statement select another item

            int addItem = int.Parse(GetUserInput("Do you want to add another item or go to checkout?(1/2) "));
            switch (addItem)
            {
                case 1:
                // addItem method
                    break;
                case 2:
                    //checkout method
                    break;
                default:
                    GetUserInput("Please select one of the options");
                        break;
            }



            // checkout display total


            // ask for payment method


            // print receipt


            //new order print menu over
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

            foreach (Item item in items)
            {
                Console.WriteLine(item.Name);
            }
        }
        // TODO create addItem method

        // TODO create checkOut method


    }
}
