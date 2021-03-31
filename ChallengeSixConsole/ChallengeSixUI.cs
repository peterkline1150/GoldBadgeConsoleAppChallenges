using ChallengeSixRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSixConsole
{
    public class ChallengeSixUI
    {
        private readonly CarRepository _carRepo = new CarRepository();
        public void Run()
        {
            SeedCars();
            Start();
        }

        private void Start()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the car comparison console.\n" +
                    "What would you like to do?\n\n" +
                    "1. Add a car to the Directory.\n" +
                    "2. View all cars in the directory.\n" +
                    "3. View a list of certain cars in the directory (and more specific details).\n" +
                    "4. Update a car in the directory.\n" +
                    "5. Delete a car in the directory.\n" +
                    "6. Exit.\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        ViewAllCars();
                        break;
                    case "3":
                        ViewCertainCars();
                        break;
                    case "4":
                        UpdateCar();
                        break;
                    case "5":
                        DeleteCar();
                        break;
                    case "6":
                        Console.WriteLine("You may now exit the console.\n");
                        continueRunning = false;
                        PressAnyKey();
                        break;
                    default:
                        break;
                }
            }
        }

        private void UpdateCar()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the car you wish to update:");
            string name = Console.ReadLine();

            ICar carToUpdate = _carRepo.GetCarByName(name);

            if (carToUpdate is GasCar)
            {
                carToUpdate = GasCarSetup(true);
                GasCar gasCarToUpdate = (GasCar)Convert.ChangeType(carToUpdate, typeof(GasCar));
                if (_carRepo.UpdateGasCar(name, gasCarToUpdate))
                {
                    Console.WriteLine("Car updated successfully.\n");
                }
                else
                {
                    Console.WriteLine("Invalid. Returning to main menu.\n");
                }
            }
            else if (carToUpdate is HybridCar)
            {
                carToUpdate = HybridCarSetup(true);
                HybridCar hybridCarToUpdate = (HybridCar)Convert.ChangeType(carToUpdate, typeof(HybridCar));
                if (_carRepo.UpdateHybridCar(name, hybridCarToUpdate))
                {
                    Console.WriteLine("Car updated successfully.\n");
                }
                else
                {
                    Console.WriteLine("Invalid. Returning to main menu.\n");
                }
            }
            else if (carToUpdate is ElectricCar)
            {
                carToUpdate = ElectricCarSetup(true);
                ElectricCar electricCarToUpdate = (ElectricCar)Convert.ChangeType(carToUpdate, typeof(ElectricCar));
                if (_carRepo.UpdateElectricCar(name, electricCarToUpdate))
                {
                    Console.WriteLine("Car updated successfully.\n");
                }
                else
                {
                    Console.WriteLine("Invalid. Returning to main menu.\n");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong.\n");
            }
            PressAnyKey();
        }

        private void DeleteCar()
        {
            Console.Clear();

            Console.WriteLine("What is the name of the car you would like to delete?\n");
            string name = Console.ReadLine();

            ICar carToDelete = _carRepo.GetCarByName(name);
            if (_carRepo.DeleteCar(carToDelete))
            {
                Console.WriteLine("Car deleted successfully.\n");
            }
            else
            {
                Console.WriteLine("Car was not deleted. Returning to main menu.\n");
            }
            PressAnyKey();
        }

        private void AddCar()
        {
            Console.Clear();

            bool continueAsking = false;
            do
            {
                Console.WriteLine("Which type of car do you want to add?\n" +
                    "1. Gas\n" +
                    "2. Hybrid\n" +
                    "3. Electric\n");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    IGasCar gasCar = GasCarSetup(false);

                    if (_carRepo.CreateCar(gasCar))
                    {
                        Console.WriteLine("Car was created successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Car was not created successfully. Returning to main menu.\n");
                    }
                }
                else if (choice == "2")
                {
                    IHybridCar hybridCar = HybridCarSetup(false);

                    if (_carRepo.CreateCar(hybridCar))
                    {
                        Console.WriteLine("Car was created successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Car was not created successfully. Returning to main menu.\n");
                    }
                }
                else if (choice == "3")
                {
                    IElectricCar electricCar = ElectricCarSetup(false);

                    if (_carRepo.CreateCar(electricCar))
                    {
                        Console.WriteLine("Car was created successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Car was not created successfully. Returning to main menu.\n");
                    }
                }
                else
                {
                    Console.WriteLine("/nPlease enter a valid number.\n");
                    continueAsking = true;
                }

            } while (continueAsking);
            PressAnyKey();
        }

        private void ViewAllCars()
        {
            Console.Clear();

            Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}",
                "Name",
                "Weight",
                "Top Speed\n"));

            List<ICar> allCars = _carRepo.ReadAllCars();
            foreach (ICar car in allCars)
            {
                Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}",
                    $"{car.Name}",
                    $"{car.Weight} lbs.",
                    $"{car.TopSpeed:0.0} MPH\n"));
            }
            PressAnyKey();
        }

        private void ViewCertainCars()
        {
            Console.Clear();

            bool continueAsking = false;
            do
            {
                Console.WriteLine("Which type of car do you want to view?\n" +
                        "1. Gas\n" +
                        "2. Hybrid\n" +
                        "3. Electric\n");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    List<ICar> listOfGasCars = _carRepo.ReadGasCars();
                    Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}",
                        "\nName",
                        "Weight",
                        "Top Speed",
                        "MPGCountry",
                        "MPGHighway",
                        "Tank Capacity\n"));
                    foreach (GasCar gasCar in listOfGasCars)
                    {
                        Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}",
                            $"{gasCar.Name}",
                            $"{gasCar.Weight} lbs.",
                            $"{gasCar.TopSpeed:0.0} MPH",
                            $"{gasCar.MPGCountry} MPG",
                            $"{gasCar.MPGHighway} MPG",
                            $"{gasCar.TankCapacity} Gallons"));
                    }
                }
                else if (choice == "2")
                {
                    List<ICar> listOfHybridCars = _carRepo.ReadHybridCars();
                    Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}",
                        "\nName",
                        "Weight",
                        "Top Speed",
                        "MPGCountry",
                        "MPGHighway",
                        "Tank Capacity",
                        "Battery Capacity\n"));
                    foreach (HybridCar hybridCar in listOfHybridCars)
                    {
                        Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}",
                            $"{hybridCar.Name}",
                            $"{hybridCar.Weight} lbs.",
                            $"{hybridCar.TopSpeed:0.0} MPH",
                            $"{hybridCar.MPGCountry:0.0} MPG",
                            $"{hybridCar.MPGHighway:0.0} MPG",
                            $"{hybridCar.TankCapacity} Gallons",
                            $"{hybridCar.BatteryCapacity:0.0} kWh"));
                    }
                }
                else if (choice == "3")
                {
                    List<ICar> listOfElectricCars = _carRepo.ReadElectricCars();
                    Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}",
                        "\nName",
                        "Weight",
                        "Top Speed",
                        "MPBCountry",
                        "MPBHighway",
                        "Battery Capacity\n"));
                    foreach (ElectricCar electricCar in listOfElectricCars)
                    {
                        Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}",
                            $"{electricCar.Name}",
                            $"{electricCar.Weight} lbs.",
                            $"{electricCar.TopSpeed:0.0} MPH",
                            $"{electricCar.MPBCountry:0.0} MPG",
                            $"{electricCar.MPBHighway:0.0} MPG",
                            $"{electricCar.BatteryCapacity:0.0} kWh"));
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number from 1-3.\n");
                    continueAsking = true;
                }
            } while (continueAsking);
            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }

        private IGasCar GasCarSetup(bool isUpdating)
        {
            GasCar newGasCar = new GasCar();

            if (isUpdating == false)
            {
                Console.WriteLine("\nEnter the name of the car:");
                newGasCar.Name = Console.ReadLine();
            }
            Console.WriteLine("\nEnter the weight of the car (in whole number lbs.):");
            newGasCar.Weight = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the top speed of the car:");
            newGasCar.TopSpeed = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the MPG in the country of the car:");
            newGasCar.MPGCountry = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the MPG on the highway of the car:");
            newGasCar.MPGHighway = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the tank capacity of the car:");
            newGasCar.TankCapacity = int.Parse(Console.ReadLine());

            return newGasCar;
        }

        private IHybridCar HybridCarSetup(bool isUpdating)
        {
            HybridCar newHybridCar = new HybridCar();

            if (isUpdating == false)
            {
                Console.WriteLine("\nEnter the name of the car:");
                newHybridCar.Name = Console.ReadLine();
            }
            Console.WriteLine("\nEnter the weight of the car (in whole number lbs.):");
            newHybridCar.Weight = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the top speed of the car:");
            newHybridCar.TopSpeed = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the MPG in the country of the car:");
            newHybridCar.MPGCountry = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the MPG on the highway of the car:");
            newHybridCar.MPGHighway = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the tank capacity of the car:");
            newHybridCar.TankCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the battery capacity of the car (in kWh):");
            newHybridCar.BatteryCapacity = double.Parse(Console.ReadLine());

            return newHybridCar;
        }

        private IElectricCar ElectricCarSetup(bool isUpdating)
        {
            ElectricCar newElectricCar = new ElectricCar();

            if (isUpdating == false)
            {
                Console.WriteLine("\nEnter the name of the car:");
                newElectricCar.Name = Console.ReadLine();
            }
            Console.WriteLine("\nEnter the weight of the car (in whole number lbs.):");
            newElectricCar.Weight = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the top speed of the car:");
            newElectricCar.TopSpeed = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the MPB (miles per full battery charge) in the country of the car:");
            newElectricCar.MPBCountry = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the MPB (miles per full battery charge) on the highway of the car:");
            newElectricCar.MPBHighway = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the battery capacity of the car (in kWh):");
            newElectricCar.BatteryCapacity = double.Parse(Console.ReadLine());

            return newElectricCar;
        }

        private void SeedCars()
        {
            GasCar gasCar = new GasCar("Honda", 8000, 85.6, 24.5, 15.4, 30);
            HybridCar hybridCar = new HybridCar("Mercedes", 6000, 70.2, 50.3, 42.8, 20, 15);
            ElectricCar electricCar = new ElectricCar("Tesla", 4000, 90.6, 20.1, 30.2, 24.1);

            _carRepo.CreateCar(gasCar);
            _carRepo.CreateCar(hybridCar);
            _carRepo.CreateCar(electricCar);
        }
    }
}
