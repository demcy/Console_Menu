using System;
using System.Collections.Generic;
using System.Linq;

namespace MENU
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu refMenu;
            List<Menu> menuHistory = new List<Menu>();
            
            DerivedMenu randomMenu = new DerivedMenu("RANDOM");
            DerivedMenu manualMenu = new DerivedMenu("MANUAL");
            DerivedMenu createMenu = new DerivedMenu("CREATE", new List<Menu>() {randomMenu, manualMenu});
            DerivedMenu deleteMenu = new DerivedMenu("DELETE");
            DerivedMenu startMenu = new DerivedMenu("MENU", new List<Menu>() {createMenu, deleteMenu});
            
            
            refMenu = startMenu;
            menuHistory.Add(refMenu);
            
            while(refMenu.Action!="BACK")
            {             
                refMenu.Show();
                refMenu = refMenu.Options.FirstOrDefault(n => n.name == refMenu.Action);
                if (refMenu.name == "BACK" && menuHistory[menuHistory.Count-1]==startMenu)
                {
                    refMenu.Action = "BACK";
                }
                else if (refMenu.name == "BACK")
                {
                    menuHistory.RemoveAt(menuHistory.Count-1);
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