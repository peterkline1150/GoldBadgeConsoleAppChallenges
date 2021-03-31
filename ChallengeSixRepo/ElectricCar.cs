using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSixRepo
{
    public class ElectricCar : IElectricCar
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public double TopSpeed { get; set; }
        public double MPBCountry { get; set; }
        public double MPBHighway { get; set; }
        public double BatteryCapacity { get; set; }
        public ElectricCar()
        {

        }
        public ElectricCar(string name, int weight, double topSpeed, double mpbCountry, double mpbHighway, double batteryCapacity)
        {
            Name = name;
            Weight = weight;
            TopSpeed = topSpeed;
            MPBCountry = mpbCountry;
            MPBHighway = mpbHighway;
            BatteryCapacity = batteryCapacity;
        }
    }
}
