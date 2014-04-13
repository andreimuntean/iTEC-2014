using System;
using System.Collections.Generic;

namespace iTEC2014
{
    public struct Cost
    {
        public double Price { get; private set; }
        public string Name { get; private set; }
        
        public Cost(double price, string name) : this()
        {
            Price = price;
            Name = name;
        }
    }

    static class BudgetManager
    {
        public static List<Cost>CalculateOptimalBudget(List<Item> items, double budget)
        {
            if (budget <= 0)
                return null;

            var elements = new List<Cost>();
            var totalPoints = 0;

            items.ForEach(item =>
            {
                totalPoints += item.Points;
            });

            foreach (var item in items)
            {
                double price = item.Points * budget / totalPoints;
                elements.Add(new Cost(Math.Round(price, 2), item.Name));
            }

            return elements;
        }
    }
}
