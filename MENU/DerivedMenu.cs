using System.Collections.Generic;

namespace MENU
{
    public class DerivedMenu : Menu
    {
        public DerivedMenu(string n)
        {
            name = n;
        }

        public DerivedMenu(string n, List<Menu> options)
        {
            name = n;

            Options = options;
        }
    }
}