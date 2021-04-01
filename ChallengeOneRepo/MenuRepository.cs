using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class MenuRepository
    {
        List<Menu> _menuDirectory = new List<Menu>();

        //CRUD - Create, Read, Update, Delete

        //Create
        public bool AddMenuItem(Menu menuItem)
        {
            int count = _menuDirectory.Count;
            _menuDirectory.Add(menuItem);

            if (count < _menuDirectory.Count)
            {
                return true;
            }
            return false;
        }

        //Read
        public List<Menu> ReadMenuItems()
        {
            return _menuDirectory;
        }

        //Update - not necessary based on prompt

        //Delete
        public bool DeleteMenuItem(Menu menuItem)
        {
            int count = _menuDirectory.Count;
            _menuDirectory.Remove(menuItem);

            if (count > _menuDirectory.Count)
            {
                return true;
            }
            return false;
        }
    }
}
