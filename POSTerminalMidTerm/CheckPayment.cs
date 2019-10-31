using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    class CheckPayment : Payment
    {
        public int CheckNumber { get; set; }

        public override void GetPayment(double total)
        {
            ChargeAmount = total;
            Console.Write("Enter Check Number");
            CheckNumber = int.Parse(Console.ReadLine());
        }
    }
}
