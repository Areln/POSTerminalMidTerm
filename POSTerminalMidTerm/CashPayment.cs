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
            //replace with the validation methods
            Input = Validate.ParseDoubleFromString("Enter amount of cash you are giving:");
            if (Input >= total)
            {
                Change = Input - total;
            }
            else
            {
                Console.WriteLine("Not enough money");
            }
        }
        public override string ToString()
        {
            return $"Payment Type: Cash\n{Input:C2}\nChange: {Change:C2}"; 
        }
    }
}
