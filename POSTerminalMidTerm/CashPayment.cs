using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    class CashPayment : Payment
    {
        public double Input { get; set; }

        public double Change { get; set; }

        public CashPayment() { }

        public override void GetPayment(double total)
        {
            
            ChargeAmount = total;
            Console.Write("Enter amount of cash you are giving:");
            //replace with the validation methods
            Input = double.Parse(Console.ReadLine());
            if (Input >= total)
            {
                Change = Input - total;
            }
            else
            {
                Console.WriteLine("Not enough money");
            }

        }
    }
}
