using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class MenuRepository
    {
        List<Menu> _menuRepo = new List<Menu>();

        //CRUD - Create, Read, Update, Delete

        //Create
        public bool AddMenuItem(Menu menuItem)
        {
            int count = _menuRepo.Count;
            _menuRepo.Add(menuItem);

            if (count < _menuRepo.Count)
            {
                return true;
            }
            return false;
        }

        //Read
        public List<Menu> ReadMenuItems()
        {
            return _menuRepo;
        }

        //Update - not necessary based on prompt

        //Delete
        public bool DeleteMenuItem(Menu menuItem)
        {
            int count = _menuRepo.Count;
            _menuRepo.Remove(menuItem);

            if (count > _menuRepo.Count)
            {
                return true;
            }
            return false;
        }
    }
}
