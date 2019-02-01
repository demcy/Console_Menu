using System.Collections.Generic;
using System.Linq;

namespace MENU
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Menu refMenu;
            var menuHistory = new List<Menu>();

            var randomMenu = new DerivedMenu("RANDOM");
            var manualMenu = new DerivedMenu("MANUAL");
            var createMenu = new DerivedMenu("CREATE", new List<Menu> {randomMenu, manualMenu});
            var deleteMenu = new DerivedMenu("DELETE");
            var startMenu = new DerivedMenu("MENU", new List<Menu> {createMenu, deleteMenu});


            refMenu = startMenu;
            menuHistory.Add(refMenu);

            while (refMenu.Action != "BACK")
            {
                refMenu.Show();
                refMenu = refMenu.Options.FirstOrDefault(n => n.name == refMenu.Action);
                if (refMenu.name == "BACK" && menuHistory[menuHistory.Count - 1] == startMenu)
                {
                    refMenu.Action = "BACK";
                }
                else if (refMenu.name == "BACK")
                {
                    menuHistory.RemoveAt(menuHistory.Count - 1);
                    refMenu = menuHistory[menuHistory.Count - 1];
                }
                else
                {
                    refMenu.Action = "Default";
                    menuHistory.Add(refMenu);
                }
            }
        }
    }
}