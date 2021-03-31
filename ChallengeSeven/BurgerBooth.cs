using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSeven
{
    public class BurgerBooth
    {
        public int NumberOfTotalPeople { get 
            {
                return NumberOfVeggieBurgers + NumberOfBurgers + NumberOfHotdogs;
            }
        }
        public int NumberOfVeggieBurgers { get; set; }
        public int NumberOfBurgers { get; set; }
        public int NumberOfHotdogs { get; set; }
        public double PricePerVeggieBurger { get; set; }
        public double PricePerBurger { get; set; }
        public double PricePerHotDog { get; set; }
        public double LumpSum { get; set; }
        public double CostOfVeggieBurgers { get 
            {
                return NumberOfVeggieBurgers * PricePerVeggieBurger;
            }
        }
        public double CostOfBurgers { get 
            {
                return NumberOfBurgers * PricePerBurger;
            }
        }
        public double CostOfHotDogs { get 
            {
                return NumberOfHotdogs * PricePerHotDog;
            }
        }
        public double TotalCost { get 
            {
                return ((PricePerVeggieBurger * NumberOfVeggieBurgers) + (PricePerBurger * NumberOfBurgers) + (PricePerHotDog * NumberOfHotdogs) + LumpSum);
            }
        }
        public BurgerBooth()
        {

        }
        public BurgerBooth(int numberOfVeggieBurgers, int numberOfBurgers, int numberOfHotDogs,
            double pricePerVeggieBurger, double pricePerBurger, double pricePerHotDog, double lumpSum)
        {
            NumberOfVeggieBurgers = numberOfVeggieBurgers;
            NumberOfBurgers = numberOfBurgers;
            NumberOfHotdogs = numberOfHotDogs;
            PricePerVeggieBurger = pricePerVeggieBurger;
            PricePerBurger = pricePerBurger;
            PricePerHotDog = pricePerHotDog;
            LumpSum = lumpSum;
        }
    }
}
