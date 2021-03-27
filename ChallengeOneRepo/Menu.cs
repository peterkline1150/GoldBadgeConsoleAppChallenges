﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public int Price { get; set; }
        public Menu()
        {

        }
        public Menu(int mealNumber, string mealName, string description, List<string> ingredients, int price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public void AddIngredientsToList(string ingredient)
        {
            Ingredients.Add(ingredient);
        }
    }
}
