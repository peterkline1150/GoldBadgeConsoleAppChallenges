using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourRepo
{
    public enum EventType { Golf, Bowling, Amusement_Park, Concert }
    public class Outing
    {
        public EventType EventType { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public double TotalCostPerPerson { get; set; }
        public double TotalCost { get
            {
                return NumberOfPeople * TotalCostPerPerson;
            }
        }
        public Outing()
        {

        }
        public Outing(EventType eventType, int numberOfPeople, DateTime date, double totalCostPerPerson)
        {
            EventType = eventType;
            NumberOfPeople = numberOfPeople;
            Date = date;
            TotalCostPerPerson = totalCostPerPerson;
        }
    }
}
