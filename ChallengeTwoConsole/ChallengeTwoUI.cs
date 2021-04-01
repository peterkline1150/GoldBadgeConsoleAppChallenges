using ChallengeTwoRepo;
using ChallengeTwoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsole
{
    public class ChallengeTwoUI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaimQueue();
            Start();
        }

        private void Start()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Claims Program!\n" +
                    "Please select a number:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        SeeClaims();
                        break;
                    case "2":
                        NextClaimInQueue();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("You may now exit the console.\n");
                        continueToRun = false;
                        PressAnyKey();
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Try again.\n");
                        PressAnyKey();
                        break;
                }
            }
        }

        private void SeeClaims()
        {
            Console.Clear();

            Queue<Claim> queueOfClaims = _claimRepo.ReadClaims();

            Console.WriteLine(string.Format("{0,-10}{1,-10}{2,-25}{3,-10}{4,-20}{5,-20}{6,-20}",
                "CaimID",
                "Type",
                "Description",
                "Amount",
                "DateOfAccident",
                "DateOfClaim",
                "IsValid"));

            Console.WriteLine("\n");

            foreach (Claim claim in queueOfClaims)
            {
                Console.WriteLine(string.Format("{0,-10}{1,-10}{2,-25}{3,-10}{4,-20}{5,-20}{6,-20}",
                    $"{claim.ClaimID}",
                    $"{claim.ClaimType}",
                    $"{claim.Description}",
                    $"${claim.ClaimAmount:0.00}",
                    $"{claim.DateOfIncident:M/d/yy}",
                    $"{claim.DateOfClaim:M/d/yy}",
                    $"{claim.IsValid}"));
            }

            PressAnyKey();
        }

        private void NextClaimInQueue()
        {
            Console.Clear();

            Console.WriteLine("Here are the details for the next claim to be handled:\n\n");

            Claim nextClaim = _claimRepo.PeekClaim();

            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount:0.00}\n" +
                $"DateOfAccident: {nextClaim.DateOfIncident:M/d/yy}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim:M/d/yy}\n" +
                $"IsValid: {nextClaim.IsValid}\n\n" +
                "Do you want to deal with this claim now(y/n)?");

            string choice = Console.ReadLine().ToLower();

            if (choice == "y")
            {
                _claimRepo.DequeueClaim();
                Console.WriteLine("The claim has been removed from the queue.\n");
            }
            else if (choice == "n")
            {
                Console.WriteLine("OK, we will return you to the main menu.\n");
            }
            else
            {
                Console.WriteLine("Invalid input. Returning to main menu.\n");
            }

            if (_claimRepo.ReadClaims().Count == 0)
            {
                Console.WriteLine("\nAll claims have been dealt with.\n");
            }

            PressAnyKey();
        }

        private void NewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.Write("Enter the claim id: ");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.Write("Enter the claim type: ");
            string claimType = Console.ReadLine().ToLower();
            if (claimType == "car")
            {
                newClaim.ClaimType = ClaimType.Car;
            }
            else if (claimType == "home")
            {
                newClaim.ClaimType = ClaimType.Home;
            }
            else if (claimType == "theft")
            {
                newClaim.ClaimType = ClaimType.Theft;
            }
            else
            {
                Console.WriteLine("Invalid claim type. Returning to main menu.\n");
                PressAnyKey();
                return;
            }
            Console.Write("Enter a claim description: ");
            newClaim.Description = Console.ReadLine();
            Console.Write("Amount of Damage: $");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());
            Console.Write("Date of Accident: ");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.Write("Date of Claim: ");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            if (newClaim.IsValid == true)
            {
                Console.WriteLine("This claim is valid.\n");
            }
            else
            {
                Console.WriteLine("This claim is invalid.\n");
            }

            if (_claimRepo.CreateClaim(newClaim))
            {
                Console.WriteLine("\nClaim has been successfully created.\n");
            }
            else
            {
                Console.WriteLine("\nSomething went wrong. Returning to main menu.\n");
            }
            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("\nPress and key to continue...\n");
            Console.ReadKey();
        }

        private void SeedClaimQueue()
        {
            Claim claimOne = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim claimTwo = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim claimThree = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));

            _claimRepo.CreateClaim(claimOne);
            _claimRepo.CreateClaim(claimTwo);
            _claimRepo.CreateClaim(claimThree);
        }
    }
}
