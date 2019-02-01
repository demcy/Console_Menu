using System;
using System.Collections.Generic;
using System.Linq;

namespace MENU
{
    public class Menu
    {
        public string name;
        public List<Menu> Options;
        public string Action;
        private string[] OptionNumbers;
        private int count;

        public void Show()
        {
            count = 0;
            Console.Clear();
            Console.WriteLine(name);
            if (Options == null)
            {
                Options = new List<Menu>();
                Options.Add(new DerivedMenu("BACK"));
            }
            else if (Options.Where(v => v.name == "BACK").Count() == 0)
            {
                Options.Add(new DerivedMenu("BACK"));
            }
            OptionNumbers = new string[Options.Count];
            foreach (var o in Options)
            {
                OptionNumbers[count++] = count.ToString();
                Console.WriteLine(count + " ) " + o.name);               
            }
            while (!OptionNumbers.Contains(Action))
            {
                Action = Console.ReadLine();                
            }           
            Action = Options[Int32.Parse(Action)-1].name;
        }
    }
}