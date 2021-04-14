using System;
using System.Linq;

namespace PizzaOrderingSystem.Lib
{
    public delegate decimal DiscountPolicy(PizzaOrder order);
    public class PizzaOrderingSystem
    {
        private DiscountPolicy _discountPolicy;

        public PizzaOrderingSystem(DiscountPolicy discountPolicy)
        {
            this._discountPolicy = discountPolicy;
        }

        public decimal ComputePrice(PizzaOrder order)
        {
            if (order is null)
                throw new ArgumentNullException("order");

            if (order.Pizzas is null)
                throw new ArgumentException("Invalid Pizza List", "order", null);

            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            decimal discountedValue = _discountPolicy(order);
            return nonDiscounted-discountedValue;
        }

        
    }
}
