using ChallengeFourRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourConsole
{
    public class ChallengeFourUI
    {
        private readonly OutingRepository _outingRepo = new OutingRepository();
        public void Run()
        {
            SeedOutings();
            Start();
        }

        private void Start()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. Display a list of all outings.\n" +
                    "2. Add an outing.\n" +
                    "3. View the cost of all outings.\n" +
                    "4. View the cost of all outings by type.\n" +
                    "5. Exit\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayAllOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        ViewCostOfAllOutings();
                        break;
                    case "4":
                        ViewCostByType();
                        break;
                    case "5":
                        Console.WriteLine("You may now exit.\n");
                        continueRunning = false;
                        PressAnyKey();
                        break;
                    default:
                        break;
                }
            }
        }

        private double AddCostOfList(List<Outing> listOfOutings)
        {
            double totalCost = 0;
            foreach (Outing outing in listOfOutings)
            {
                totalCost += outing.TotalCost;
            }

            return totalCost;
        }

        private void ViewCostByType()
        {
            Console.Clear();
            List<Outing> listOfGolfOutings = new List<Outing>();
            List<Outing> listOfAmusementParkOutings = new List<Outing>();
            List<Outing> listOfConcertOutings = new List<Outing>();
            List<Outing> listOfBowlingOutings = new List<Outing>();

            foreach (Outing outing in _outingRepo.ReadOutings())
            {
                switch (outing.EventType)
                {
                    case EventType.Golf:
                        listOfGolfOutings.Add(outing);
                        break;
                    case EventType.Bowling:
                        listOfBowlingOutings.Add(outing);
                        break;
                    case EventType.Amusement_Park:
                        listOfAmusementParkOutings.Add(outing);
                        break;
                    case EventType.Concert:
                        listOfConcertOutings.Add(outing);
                        break;
                    default:
                        break;
                }
            }
            double costForGolf = AddCostOfList(listOfGolfOutings);
            double costForBowling = AddCostOfList(listOfBowlingOutings);
            double costForAmusementPark = AddCostOfList(listOfAmusementParkOutings);
            double costForConcert = AddCostOfList(listOfConcertOutings);

            Console.WriteLine("Total cost by type:\n");
            Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}",
                "Golf",
                "Bowling",
                "Amusement Park",
                "Concert\n"));

            Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}",
                $"${costForGolf:0.00}",
                $"${costForBowling:0.00}",
                $"${costForAmusementPark:0.00}",
                $"${costForConcert:0.00}"));

            PressAnyKey();
        }

        private void ViewCostOfAllOutings()
        {
            Console.Clear();
            List<Outing> allOutings = _outingRepo.ReadOutings();

            double totalCost = AddCostOfList(allOutings);
            
            Console.WriteLine($"The total cost of all outings is: ${totalCost:0.00}\n");
            PressAnyKey();
        }

        private void AddOuting()
        {
            Console.Clear();

            Outing newOuting = new Outing();

            bool continueAsking;
            do
            {
                continueAsking = false;

                Console.WriteLine("What was the event type?\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        newOuting.EventType = EventType.Golf;
                        break;
                    case "2":
                        newOuting.EventType = EventType.Bowling;
                        break;
                    case "3":
                        newOuting.EventType = EventType.Amusement_Park;
                        break;
                    case "4":
                        newOuting.EventType = EventType.Concert;
                        break;
                    default:
                        Console.WriteLine("Invalid entry.\n");
                        continueAsking = true;
                        break;
                }
            } while (continueAsking);

            Console.WriteLine("How many people attended the event?\n");
            newOuting.NumberOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the date of the event? (m/d/yy)");
            newOuting.Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What was the total cost per person?\n");
            newOuting.TotalCostPerPerson = double.Parse(Console.ReadLine());

            if (_outingRepo.CreateOuting(newOuting))
            {
                Console.WriteLine("Outing added successfully.\n");
            }
            else
            {
                Console.WriteLine("Something went wrong. Please try again.\n");
            }
            PressAnyKey();
        }

        private void DisplayAllOutings()
        {
            Console.Clear();

            List<Outing> listOfOutings = _outingRepo.ReadOutings();

            Console.WriteLine("Here are all of the company outings:\n\n");
            Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}",
                "Event Type",
                "Number of People",
                "Date\n"));
            foreach (Outing outing in listOfOutings)
            {
                Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}",
                    $"{outing.EventType}",
                    $"{outing.NumberOfPeople}",
                    $"{outing.Date:M/d/yy}"));
            }
            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }

        private void SeedOutings()
        {
            Outing outingOne = new Outing(EventType.Bowling, 100, new DateTime(2020, 12, 10), 50);
            Outing outingTwo = new Outing(EventType.Concert, 50, new DateTime(2020, 10, 15), 40);
            Outing outingThree = new Outing(EventType.Amusement_Park, 120, new DateTime(2020, 6, 22), 60);
            Outing outingFour = new Outing(EventType.Golf, 80, new DateTime(2020, 3, 9), 30);

            _outingRepo.CreateOuting(outingOne);
            _outingRepo.CreateOuting(outingTwo);
            _outingRepo.CreateOuting(outingThree);
            _outingRepo.CreateOuting(outingFour);
        }
    }
}
