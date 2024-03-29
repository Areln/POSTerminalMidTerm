﻿using System;
using System.Collections.Generic;
using System.IO;

namespace POSTerminalMidTerm
{
    class Program
    {
        static List<Item> items = new List<Item>();
        static Receipt receipt = new Receipt();
        static string runAgain = "y";
        static string orderAgain = "y";
        static void Main(string[] args)
        {
            while (orderAgain != "n") 
            {
                Console.Clear();
                AmazonShop();

                CheckOut();

                Console.Clear();
                Console.WriteLine(receipt.ToString());

                orderAgain = Validate.GetInput("Would you like to make another order?(y/n) ").ToLower();
                runAgain = "y";
                receipt.ShoppingCart.Clear();
            }


            Console.WriteLine("\n\t\t\tThank you for shopping with us!");
        }

        public static void PrintItemList()
        {
            items = ItemListIO.LoadData();

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i+1}. {items[i].Name} ... {items[i].Price:C2} ");
            }
        }

        public static void AddToCart()
        {
            Item selectedItem = items[Validate.ParseIntFromString("Please select an item from the list: \n", 1, items.Count) - 1];
            int x = Validate.ParseIntFromString($"How many {selectedItem.Name} would you like?");
            for (int i = 0; i < x; i++)
            {
                receipt.AddItemToCart(selectedItem);
            }
            
        }

        public static void CheckOut()
        {
            int userSelection = Validate.ParseIntFromString("How are you paying for your items today?\n1.Credit Card\n2.Cash\n3.PayPal\n4.Check\n", 1, 4);

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
                    Validate.GetInput("Please select a valid payment method");
                    break;
            }
            
        }

        public static void PrintCart()
        {
            for (int i = 0; i < receipt.ShoppingCart.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {receipt.ShoppingCart[i].Name} ... {receipt.ShoppingCart[i].Price:C2}");
            }
            Console.WriteLine($"Subtotal: {receipt.Subtotal:C2}");
        }
        public static void RemoveItemFromCart()
        {
            bool hasMultiple = false;

            if (receipt.ShoppingCart.Count == 0) 
            { 
                Console.WriteLine("There are no items to remove in the cart");  
                return; 
            }

            Console.Clear();
            PrintCart();
            Item selectedItem = receipt.ShoppingCart[Validate.ParseIntFromString("Please select an item from your cart to remove: \n", 1, receipt.ShoppingCart.Count) - 1];
            // this is checking to see how many items to remove
            foreach (Item item in receipt.ShoppingCart)
            {
                if (item.Name == selectedItem.Name)
                {
                    hasMultiple = true;
                }
            }
            if (hasMultiple == true)
            {
                int removeAmount = Validate.ParseIntFromString($"How many {selectedItem.Name} would you like to remove?: \n");
                while(removeAmount > 0)
                {
                    if (receipt.ShoppingCart.Contains(selectedItem))
                    {
                        receipt.ShoppingCart.Remove(selectedItem);
                        removeAmount--;

                        receipt.Subtotal -= selectedItem.Price;
                        receipt.TaxTotal -= selectedItem.Price * selectedItem.TaxRate;
                        receipt.Total -= selectedItem.Price * (1 + selectedItem.TaxRate);
                    }
                    else
                    {
                        removeAmount = 0;
                        Console.WriteLine("test");
                    }
                }
                return;
            }
            receipt.ShoppingCart.Remove(selectedItem);
        }
        public static void AmazonShop()
        {
            Console.WriteLine("          :::          :::   :::           :::        :::::::::       ::::::::       ::::    ::: ");
            Console.WriteLine("       :+: :+:       :+:+: :+:+:        :+: :+:           :+:       :+:    :+:      :+:+:   :+:  ");
            Console.WriteLine("     +:+   +:+     +:+ +:+:+ +:+      +:+   +:+         +:+        +:+    +:+      :+:+:+  +:+   ");
            Console.WriteLine("   +#++:++#++:    +#+  +:+  +#+     +#++:++#++:       +#+         +#+    +:+      +#+ +:+ +#+    ");
            Console.WriteLine("  +#+     +#+    +#+       +#+     +#+     +#+      +#+          +#+    +#+      +#+  +#+#+#     ");
            Console.WriteLine(" #+#     #+#    #+#       #+#     #+#     #+#     #+#           #+#    #+#      #+#   #+#+#      ");
            Console.WriteLine("###     ###    ###       ###     ###     ###    #########       ########       ###    ####       ");
            Console.WriteLine();
            Console.WriteLine("Welcome to the Amazon Kiosk");

            int addItem = 0;
            while (runAgain != "n")
            {
                if (addItem != 2 && addItem != 3)
                {
                    PrintItemList();
                    AddToCart();
                }

                //switch statement select another item

                addItem = Validate.ParseIntFromString("Would you like to add another item\n1. To add item \n2. To view cart\n3. Remove item from cart\n4. Checkout", 1, 4);
                switch (addItem)
                {
                    case 1:
                        runAgain = "y";
                        Console.Clear();
                        // addItem method
                        break;
                    case 2:
                        //view cart method
                        Console.Clear();
                        PrintCart();
                        Console.Write("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 3:
                        //removes item from cart
                        RemoveItemFromCart();

                        break;
                    case 4:
                        //checkout method
                        runAgain = "n";
                        break;
                    default:
                        Validate.GetInput("Please select one of the options");
                        break;
                }

            }
        }

    }
}
