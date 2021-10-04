using System;
using System.Collections.Generic;

namespace CSharpProject
{
    class Program_4
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> Item = new Dictionary<string, int>();
            string itemName; int itemQuantity;
            Console.Write("Number of items to be added: ");
            int numberOfItems = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfItems; i++)
            {
                Console.Write("Enter Item Name: ");
                itemName = Console.ReadLine();
                Console.Write("Enter Item Quantity: ");
                itemQuantity = int.Parse(Console.ReadLine());
                Item.Add(itemName, itemQuantity);
            }
            Console.Write("Enter name of item to be purchase: ");
            itemName = Console.ReadLine();
            Console.Write("Enter quantity of item to be purchase: ");
            itemQuantity = int.Parse(Console.ReadLine());
            if (Item.ContainsKey(itemName))
            {
                if (itemQuantity <= Item[itemName])
                {
                    Item[itemName] -= itemQuantity;
                    Console.WriteLine("Sold! "+Item[itemName]+" items left");
                    if(Item[itemName] == 0 )
                    {
                        Item.Remove(itemName);
                    }
                }
                else if(itemQuantity > Item[itemName])
                {
                    Console.WriteLine("Item running low on stock! Only " + Item[itemName] + " quantity is left");
                }
            }
            else
            {
                Console.WriteLine("Item can't be sold, Item is out of stock");
            }
        }
    }
}
