using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Drink
    {
        public string Name;
        public int Price;

        public Drink(string inputLine)
        {
            string[] splitedLine = inputLine.Split(';');

            Name = splitedLine[0];
            Price = int.Parse(splitedLine[1]);
        }

        public string ReturnAsButtonText() => $"{Name}  {Price}zł";

    }
}
