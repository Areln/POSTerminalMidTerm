using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    abstract class Payment
    {
        public double ChargeAmount { get; set; }

        public abstract void GetPayment();
    }
}
