using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSixRepo
{
    public class HybridCar : IHybridCar
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public double TopSpeed { get; set; }
        public double MPGCountry { get; set; }
        public double MPGHighway { get; set; }
        public int TankCapacity { get; set; }
        public double BatteryCapacity { get; set; }
        public HybridCar()
        {

        }
        public HybridCar(string name, int weight, double topSpeed, double mpgCountry, double mpgHighway, int tankCapacity, double batteryCapacity)
        {
            Name = name;
            Weight = weight;
            TopSpeed = topSpeed;
            MPGCountry = mpgCountry;
            MPGHighway = mpgHighway;
            TankCapacity = tankCapacity;
            BatteryCapacity = batteryCapacity;
        }
    }
}
