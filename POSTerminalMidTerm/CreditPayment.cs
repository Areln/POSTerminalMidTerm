using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    class CreditPayment : Payment
    {
        public string CardNumber { get; set; }
        public DateTime CardExpiration { get; set; }
        public string CW { get; set; }

        public CreditPayment() { }

        public override void GetPayment(double total)
        {
            ChargeAmount = total;
            //prompt user to enter card info, TODO: validate and inputted info
            Console.Write("Enter Card Number: ");
            CardNumber = Console.ReadLine();
            Console.Write("Expiration Date(mm/dd/yy): ");
            CardExpiration = DateTime.Parse(Console.ReadLine());
            Console.Write("CW: ");
            CW = Console.ReadLine();

        }
    }
}
