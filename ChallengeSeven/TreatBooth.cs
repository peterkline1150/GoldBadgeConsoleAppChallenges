using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSeven
{
    public class TreatBooth
    {
        public int TotalPeople { get 
            {
                return NumberOfIceCreamCones + NumberOfPopcorn;
            }
        }
        public int NumberOfIceCreamCones { get; set; }
        public int NumberOfPopcorn { get; set; }
        public double PricePerCone { get; set; }
        public double PricePerPopcorn { get; set; }
        public double LumpSum { get; set; }
        public double CostOfPopcornBag { get 
            {
                //Assuming one bag feeds four people
                return PricePerPopcorn * 4;
            }
        }
        public double CostOfGallonOfIceCream { get 
            {
                //Assuming 32 scoops per gallon of ice cream
                return PricePerCone * 32;
            }
        }
        public double TotalMoney { get 
            {
                return ((NumberOfIceCreamCones * PricePerCone) + (NumberOfPopcorn * PricePerPopcorn) + LumpSum);
            }
        }
        public TreatBooth()
        {

        }
        public TreatBooth(int numberOfIceCreamCones, int numberOfPopcorn, double pricePerCone, double pricePerPopcorn, double lumpSum)
        {
            NumberOfIceCreamCones = numberOfIceCreamCones;
            NumberOfPopcorn = numberOfPopcorn;
            PricePerCone = pricePerCone;
            PricePerPopcorn = pricePerPopcorn;
            LumpSum = lumpSum;
        }
    }
}
