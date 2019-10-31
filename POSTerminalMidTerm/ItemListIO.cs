using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POSTerminalMidTerm
{
    class ItemListIO
    {

        public List<Item> LoadData()
        {
            List<Item> items = new List<Item>();
            StreamReader reader = new StreamReader("../../../AmazonItems.txt");
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] word = line.Split('|');
                items.Add(new Item(word[0],(ItemType)int.Parse(word[1]), double.Parse(word[2])));
                line = reader.ReadLine();
            }
            reader.Close();

            return items;
        }
    }
}
