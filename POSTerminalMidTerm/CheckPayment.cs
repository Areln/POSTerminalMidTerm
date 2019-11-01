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
            CheckNumber = Validate.ParseIntFromString("Enter Check Number: ");
        }
        public override string ToString()
        {
            return $"Check Number: {CheckNumber}\nCharge Amount: {ChargeAmount:C2}";
        }
    }
}
