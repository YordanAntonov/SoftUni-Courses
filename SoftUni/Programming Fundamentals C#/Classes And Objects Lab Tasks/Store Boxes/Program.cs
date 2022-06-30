    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Store_Boxes
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                List<Box> boxes = new List<Box>();

                string command = Console.ReadLine();

                while (command != "end")
                {
                    string[] boxProps = command.Split(' ');
                    string serialNumber = boxProps[0];
                    string itemName = boxProps[1];
                    int itemQantity = int.Parse(boxProps[2]);
                    decimal itemPrice = decimal.Parse(boxProps[3]);

                    Item item = new Item(itemName, itemPrice);

                    Box box = new Box(serialNumber, item, itemQantity);

                    boxes.Add(box);
                    command = Console.ReadLine();
                }

                List<Box> orderedBoxes = boxes.OrderByDescending(box => box.PriceForBox).ToList();

                foreach (Box box in orderedBoxes)
                {
                    Console.WriteLine(box.SerialNumber);
                    Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                    Console.WriteLine($"-- ${box.PriceForBox:f2}");
                }
            }
        }

        class Box
        {
            public Box(string serialNumber, Item item, int itemQuantity)
            {
                SerialNumber = serialNumber;
                Item = item;
                ItemQuantity = itemQuantity;
            }

            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }

            public decimal PriceForBox
            {
                get
                {
                    return this.Item.Price * this.ItemQuantity;
                }
            }
        }
        class Item
        {
            public Item(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
            public string Name { get; set; }
            public decimal Price { get; set; }

        }
    }
