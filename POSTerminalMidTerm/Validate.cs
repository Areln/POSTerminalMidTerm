using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace POSTerminalMidTerm
{
    class Validate
    {
        public static bool ValidateCardCW(string dataInput)
        {
            if (Regex.IsMatch(dataInput, @"\b[0-9]{3}\b"))
            {
                return true;
            }
            return false;
        }
        public static bool ValidateCardExpiration(string dataInput) 
        {
            if (Regex.IsMatch(dataInput, @"\b[0-9]{1,2}\/[0-9]{2}\b"))
            {
                return true;
            }
            return false;
        }
        public static bool ValidateCardNumber(string dataInput) 
        {
            if (Regex.IsMatch(dataInput, @"\b[0-9]{16}\b"))
            {
                return true;
            }
            return false;
        }
        public static bool ValidateDate(string dateInput)
        {
            if (Regex.IsMatch(dateInput, @"\b[0-9]{1,2}\/[0-9]{2}\/[0-9]{4}$\b"))
            {
                return true;
            }
            return false;
        }
        public static bool ValidateEmailAddr(string emailInput)
        {
            if (Regex.IsMatch(emailInput, @"[a-zA-Z0-9]{3,30}@[A-Za-z]{3,10}\.[A-Za-z]{2,3}$"))
            {
                return true;
            }
            return false;
        }
        public static string GetInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(message);
                return Console.ReadLine();
            }
            else
            {
                return input;
            }

        }
        public static int ParseIntFromString(string message)
        {
            try
            {
                return int.Parse(GetInput(message));
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again: ");
                return ParseIntFromString(message);
            }
        }
        public static int ParseIntFromString(string message, int min, int max)
        {
            int temp;
            try
            {
                temp = int.Parse(GetInput(message));
                if (temp <= max && temp >= min)
                {
                    return temp;
                }
                else
                {
                    Console.WriteLine("Selection out of range, try again");
                    return ParseIntFromString(message, min, max);
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again: ");
                return ParseIntFromString(message);
            }
        }
        public static double ParseDoubleFromString(string message)
        {
            try
            {
                return double.Parse(GetInput(message));
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again: ");
                return ParseIntFromString(message);
            }
        }
    }
}
