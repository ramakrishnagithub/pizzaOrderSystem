using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaOrderingSystem.Lib
{
    public static class DiscountPolicyDelegates
    {
        public static decimal BuyOneGetOneDiscount(PizzaOrder order)
        {
            if (order.Pizzas.Count < 2)
            {
                return 0m;
            }
            return order.Pizzas.Min(p => p.Price);
        }

        public static decimal FivePercentOffMorThanFiftyDollars(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            return nonDiscounted >= 50 ? nonDiscounted * 0.05m : 0M;
        }

        public static DiscountPolicy DiscountAllPizzas()
        {
            DiscountPolicy best = CreateBest(BuyOneGetOneDiscount, FivePercentOffMorThanFiftyDollars);
            return best;
        }

        private static DiscountPolicy CreateBest(params DiscountPolicy[] policies)
        {
            return order => policies.Max(policy => policy.Invoke(order));
        }
    }
}
