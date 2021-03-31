using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSeven
{
    public class Party
    {
        public BurgerBooth BurgerBooth { get; set; } = new BurgerBooth();
        public TreatBooth TreatBooth { get; set; } = new TreatBooth();
        public DateTime DateOfEvent { get; set; }
        public int TotalPeopleAtParty { get 
            {
                return BurgerBooth.NumberOfTotalPeople + TreatBooth.TotalPeople;
            }
        }
        public double TotalCost { get 
            {
                return BurgerBooth.TotalCost + TreatBooth.TotalMoney;
            }
        }
        public Party()
        {

        }
        public Party(BurgerBooth burgerBooth, TreatBooth treatBooth, DateTime dateOfEvent)
        {
            BurgerBooth = burgerBooth;
            TreatBooth = treatBooth;
            DateOfEvent = dateOfEvent;
        }
    }
}
