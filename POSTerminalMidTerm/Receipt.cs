using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    class Receipt
    {
        public List<Item> ShoppingCart = new List<Item>();
        public double Total { get; set; }
        public double Subtotal { get; set; }
        public double TaxTotal { get; set; }
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
            receipt = string.Concat(receipt, $"\nSub Total: {Subtotal:C2}");
            receipt = string.Concat(receipt, $"\nSales Tax: {TaxTotal:C2}");
            receipt = string.Concat(receipt,$"\nTotal: {Total:C2}");
            return receipt;
        }

        public void AddItemToCart(Item item)
        {
            ShoppingCart.Add(item);
            Subtotal += item.Price;
            TaxTotal += item.Price * item.TaxRate;
            Total += item.Price * (1 + item.TaxRate);
        }
    }
}
