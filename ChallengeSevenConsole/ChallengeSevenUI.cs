using ChallengeSeven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSevenConsole
{
    public class ChallengeSevenUI
    {
        private readonly BoothRepository _partyRepo = new BoothRepository();
        public void Run()
        {
            Start();
        }

        private void Start()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Barbecue Calculator!\n" +
                    "What would you like to do?\n" +
                    "1. View all parties.\n" +
                    "2. Add a party.\n" +
                    "3. Delete a party.\n" +
                    "4. Exit.");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewParties();
                        break;
                    case "2":
                        AddParty();
                        break;
                    case "3":
                        DeleteParty();
                        break;
                    case "4":
                        Console.WriteLine("You may now exit the console.\n");
                        continueRunning = false;
                        PressAnyKey();
                        break;
                    default:
                        break;
                }
            }
        }

        private void DeleteParty()
        {
            Console.Clear();
            Console.WriteLine("Enter the date of the party that you want to delete: (m/d/yy)");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Party partyToRemove = _partyRepo.FindPartyByDate(date);
            if (partyToRemove != null && _partyRepo.DeleteParty(partyToRemove))
            {
                Console.WriteLine("Party was successfully removed.\n");
            }
            else
            {
                Console.WriteLine("Party was not removed successfully. Returning to main menu.\n");
            }
            PressAnyKey();
        }

        private void AddParty()
        {
            Console.Clear();
            Party newParty = new Party();
            Console.WriteLine("What was the date of the party? (m/d/yy)");
            newParty.DateOfEvent = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\nWe will start with the Burger Booth.\n\n");

            Console.WriteLine("How many people ate a Veggie Burger?");
            newParty.BurgerBooth.NumberOfVeggieBurgers = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people ate a Normal Burger?");
            newParty.BurgerBooth.NumberOfBurgers = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people ate a Hot Dog?");
            newParty.BurgerBooth.NumberOfHotdogs = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease enter the price per unit of the following items:\n" +
                "Veggie Burger (including bun):");
            newParty.BurgerBooth.PricePerVeggieBurger = double.Parse(Console.ReadLine());
            Console.WriteLine("Normal Burger (including bun):");
            newParty.BurgerBooth.PricePerBurger = double.Parse(Console.ReadLine());
            Console.WriteLine("Hot Dog (including bun):");
            newParty.BurgerBooth.PricePerHotDog = double.Parse(Console.ReadLine());
            Console.WriteLine("\nWhat was the lump sum of everything else? (napkins, utensils, etc.)");
            newParty.BurgerBooth.LumpSum = double.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Next, we will focus on the Treat Booth.\n");
            Console.WriteLine("How many people ate an Ice Cream Cone?");
            newParty.TreatBooth.NumberOfIceCreamCones = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people ate Popcorn?");
            newParty.TreatBooth.NumberOfPopcorn = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease enter the price per unit of the following items:\n" +
                "Ice cream scoop:");
            newParty.TreatBooth.PricePerCone = double.Parse(Console.ReadLine());
            Console.WriteLine("Popcorn:");
            newParty.TreatBooth.PricePerPopcorn = double.Parse(Console.ReadLine());
            Console.WriteLine("\nWhat was the lump sum of everything else? (napkins, bowls, cones, etc.)");
            newParty.TreatBooth.LumpSum = double.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("After running the numbers, the following has been determined:\n\n" +
                $"Total cost of Veggie Burgers: ${newParty.BurgerBooth.CostOfVeggieBurgers:0.00}\n" +
                $"Total cost of Normal Burgers: ${newParty.BurgerBooth.CostOfBurgers:0.00}\n" +
                $"Total cost of Hot Dogs: ${newParty.BurgerBooth.CostOfHotDogs:0.00}\n" +
                $"Total cost of the Burger Booth: ${newParty.BurgerBooth.TotalCost:0.00}\n");
            Console.WriteLine($"Total cost of a bag of popcorn: ${newParty.TreatBooth.CostOfPopcornBag:0.00}\n" +
                $"Total cost per gallon of ice cream: ${newParty.TreatBooth.CostOfGallonOfIceCream:0.00}\n" +
                $"Total cost of the Treat Booth: ${newParty.TreatBooth.TotalMoney}\n");

            _partyRepo.CreateParty(newParty);
            PressAnyKey();
        }

        private void ViewParties()
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0,-30}{1,-30}{2,-30}{3,-30}{4,-30}",
                "Date of party",
                "Total cost of party",
                "Total burger booth tickets",
                "Total treat booth tickets",
                "Total tickets overall\n"));

            List<Party> allParties = _partyRepo.ReturnParties();
            foreach (Party party in allParties)
            {
                Console.WriteLine(String.Format("{0,-30}{1,-30}{2,-30}{3,-30}{4,-30}",
                    $"{party.DateOfEvent:M/d/yy}",
                    $"${party.TotalCost:0.00}",
                    $"{party.BurgerBooth.NumberOfTotalPeople}",
                    $"{party.TreatBooth.TotalPeople}",
                    $"{party.TotalPeopleAtParty}\n"));
            }
            PressAnyKey();
        }

        private void GetTreatBoothInfo()
        {
            Console.Clear();

            TreatBooth iceCreamBooth = new TreatBooth();
            Console.WriteLine("How many people ate an Ice Cream Cone?");
            iceCreamBooth.NumberOfIceCreamCones = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people ate Popcorn?");
            iceCreamBooth.NumberOfPopcorn = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease enter the price per unit of the following items:\n" +
                "Ice cream scoop:");
            iceCreamBooth.PricePerCone = double.Parse(Console.ReadLine());
            Console.WriteLine("Popcorn:");
            iceCreamBooth.PricePerPopcorn = double.Parse(Console.ReadLine());
            Console.WriteLine("\nWhat was the lump sum of everything else? (napkins, bowls, cones, etc.)");
            iceCreamBooth.LumpSum = double.Parse(Console.ReadLine());
        }

        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }
    }
}
