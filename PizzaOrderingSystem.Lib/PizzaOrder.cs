using System.Collections.Generic;

namespace PizzaOrderingSystem.Lib
{
    public class PizzaOrder
    {
        public PizzaOrder()
        {
            Pizzas = new List<Pizza>(2);
        }

        public List<Pizza> Pizzas { get; set; }
    }
}