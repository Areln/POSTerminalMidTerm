using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    public enum ItemType { Food, Entertainment, Clothes, Appliances}

    class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public double Price { get; set; }
        public double TaxRate { get; set; }

        public Item() { }
        public Item(string name, ItemType type, double price) 
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"{Name}, {Type}, {Price:C2}";
        }
    }
}
