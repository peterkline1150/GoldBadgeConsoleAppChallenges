using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSixRepo
{
    public class CarRepository
    {
        private readonly List<ICar> _allCarsDirectory = new List<ICar>();
        private readonly List<ICar> _gasCarsDirectory = new List<ICar>();
        private readonly List<ICar> _hybridCarsDirectory = new List<ICar>();
        private readonly List<ICar> _electricCarsDirectory = new List<ICar>();

        //CRUD

        //Create
        public bool CreateCar(ICar carToCreate)
        {
            if (carToCreate is GasCar)
            {
                int countOne = _allCarsDirectory.Count;
                int countTwo = _gasCarsDirectory.Count;

                _allCarsDirectory.Add(carToCreate);
                _gasCarsDirectory.Add(carToCreate);

                if (countOne < _allCarsDirectory.Count && countTwo < _gasCarsDirectory.Count)
                {
                    return true;
                }
            }
            else if (carToCreate is HybridCar)
            {
                int countOne = _allCarsDirectory.Count;
                int countTwo = _hybridCarsDirectory.Count;

                _allCarsDirectory.Add(carToCreate);
                _hybridCarsDirectory.Add(carToCreate);

                if (countOne < _allCarsDirectory.Count && countTwo < _hybridCarsDirectory.Count)
                {
                    return true;
                }
            }
            else if (carToCreate is ElectricCar)
            {
                int countOne = _allCarsDirectory.Count;
                int countTwo = _electricCarsDirectory.Count;

                _allCarsDirectory.Add(carToCreate);
                _electricCarsDirectory.Add(carToCreate);

                if (countOne < _allCarsDirectory.Count && countTwo < _electricCarsDirectory.Count)
                {
                    return true;
                }
            }
            return false;
        }

        //Read
        public List<ICar> ReadAllCars()
        {
            return _allCarsDirectory;
        }

        public List<ICar> ReadGasCars()
        {
            return _gasCarsDirectory;
        }

        public List<ICar> ReadHybridCars()
        {
            return _hybridCarsDirectory;
        }

        public List<ICar> ReadElectricCars()
        {
            return _electricCarsDirectory;
        }

        //Update
        public ICar GetCarByName(string name)
        {
            foreach (ICar car in _allCarsDirectory)
            {
                if (car.Name == name)
                {
                    return car;
                }
            }
            return null;
        }

        public bool UpdateGasCar (string name, GasCar newCar)
        {
            ICar oldCar = GetCarByName(name);

            if (oldCar != null && oldCar is GasCar)
            {
                GasCar oldGasCar = (GasCar)Convert.ChangeType(oldCar, typeof(GasCar));
                oldGasCar.Name = newCar.Name;
                oldGasCar.Weight = newCar.Weight;
                oldGasCar.TopSpeed = newCar.TopSpeed;
                oldGasCar.MPGCountry = newCar.MPGCountry;
                oldGasCar.MPGHighway = newCar.MPGHighway;
                oldGasCar.TankCapacity = newCar.TankCapacity;

                return true;
            }
            return false;
        }

        public bool UpdateHybridCar(string name, HybridCar newCar)
        {
            ICar oldCar = GetCarByName(name);

            if (oldCar != null && oldCar is HybridCar)
            {
                HybridCar oldHybridCar = (HybridCar)Convert.ChangeType(oldCar, typeof(HybridCar));
                oldHybridCar.Name = newCar.Name;
                oldHybridCar.Weight = newCar.Weight;
                oldHybridCar.TopSpeed = newCar.TopSpeed;
                oldHybridCar.MPGCountry = newCar.MPGCountry;
                oldHybridCar.MPGHighway = newCar.MPGHighway;
                oldHybridCar.TankCapacity = newCar.TankCapacity;
                oldHybridCar.BatteryCapacity = newCar.BatteryCapacity;

                return true;
            }
            return false;
        }

        public bool UpdateElectricCar(string name, ElectricCar newCar)
        {
            ICar oldCar = GetCarByName(name);

            if (oldCar != null && oldCar is ElectricCar)
            {
                ElectricCar oldElectricCar = (ElectricCar)Convert.ChangeType(oldCar, typeof(ElectricCar));
                oldElectricCar.Name = newCar.Name;
                oldElectricCar.Weight = newCar.Weight;
                oldElectricCar.TopSpeed = newCar.TopSpeed;
                oldElectricCar.MPBCountry = newCar.MPBCountry;
                oldElectricCar.MPBHighway = newCar.MPBHighway;
                oldElectricCar.BatteryCapacity = newCar.BatteryCapacity;

                return true;
            }
            return false;
        }

        //Delete
        public bool DeleteCar(ICar carToDelete)
        {
            if (carToDelete is GasCar)
            {
                int countOne = _allCarsDirectory.Count;
                int countTwo = _gasCarsDirectory.Count;

                _allCarsDirectory.Remove(carToDelete);
                _gasCarsDirectory.Remove(carToDelete);

                if (countOne > _allCarsDirectory.Count && countTwo > _gasCarsDirectory.Count)
                {
                    return true;
                }
            }
            else if (carToDelete is HybridCar)
            {
                int countOne = _allCarsDirectory.Count;
                int countTwo = _hybridCarsDirectory.Count;

                _allCarsDirectory.Remove(carToDelete);
                _hybridCarsDirectory.Remove(carToDelete);

                if (countOne > _allCarsDirectory.Count && countTwo > _hybridCarsDirectory.Count)
                {
                    return true;
                }
            }
            else if (carToDelete is ElectricCar)
            {
                int countOne = _allCarsDirectory.Count;
                int countTwo = _electricCarsDirectory.Count;

                _allCarsDirectory.Remove(carToDelete);
                _electricCarsDirectory.Remove(carToDelete);

                if (countOne > _allCarsDirectory.Count && countTwo > _electricCarsDirectory.Count)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
