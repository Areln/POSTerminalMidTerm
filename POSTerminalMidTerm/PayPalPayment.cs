using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    class PayPalPayment : Payment
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public override void GetPayment(double total)
        {
            string temp;
            ChargeAmount = total;
 
            while (string.IsNullOrWhiteSpace(Email))
            {
                temp = Validate.GetInput("Email: ");
                if (Validate.ValidateEmailAddr(temp))
                {
                    Email = temp;
                    break;
                }
                Console.WriteLine("Not A valid Email, try again");
            }
            Password = Validate.GetInput("Enter Password: ");
        }
        public override string ToString()
        {
            return $"EMail: {Email}\nCharge Amount: {ChargeAmount:C2}";
        }
    }
}
