using System;
using System.Collections.Generic;
using System.Linq;

namespace MENU
{
    public class Menu
    {
        public string Action;
        private int count;
        public string name;
        private string[] OptionNumbers;
        public List<Menu> Options;

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

            while (!OptionNumbers.Contains(Action)) Action = Console.ReadLine();

            Action = Options[int.Parse(Action) - 1].name;
        }
    }
}