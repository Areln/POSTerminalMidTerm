using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    class Receipt
    {
        public List<Item> ShoppingCart { get; set; }
        public double Total { get; set; }
        public double Subtotal { get; set; }
        public Payment PaymentType { get; set; }

        public Receipt() { }
        public override string ToString()
        {
            string receipt = "";
            for (int i = 0; i < ShoppingCart.Count; i++)
            {
                receipt = string.Concat(receipt, $"{i+1}) {ShoppingCart[i].Name} ... {ShoppingCart[i].Price}\n");
            }
            receipt = string.Concat(receipt, "\n", PaymentType.ToString());
            return receipt;
        }
    }
}
