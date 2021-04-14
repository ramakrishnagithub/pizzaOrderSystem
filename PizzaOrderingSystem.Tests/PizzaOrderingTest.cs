#region Namespaces
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PizzaOrderingSystem.Lib;
#endregion Namespaces

namespace PizzaOrderingSystem.Tests
{
    [TestClass]
    public class PizzaOrderingTest
    {
        #region Fields
        PizzaOrderingSystem.Lib.PizzaOrderingSystem pizzaOrderingSystem;
        PizzaOrderingSystem.Lib.DiscountPolicy _discountPolicy;
        #endregion Fields

        [TestInitialize]
        public void PizzaOrderingTest_Init()
        {            
            pizzaOrderingSystem = new Lib.PizzaOrderingSystem(DiscountPolicyDelegates.DiscountAllPizzas());
        }

        [TestMethod]
        public void ShouldThrowArgumentNullException()
        {            
            var exception = Assert.ThrowsException<ArgumentNullException>(() => pizzaOrderingSystem.ComputePrice(null));
            Assert.AreEqual("order", exception.ParamName);
        }

        [TestMethod]
        public void Test_BuyOneGetOne_PizzaDiscount()
        {           
            var order = new PizzaOrder();
            order.Pizzas.Add(new Pizza() {
                Crust=PizzaCrust.Regular,
                Price=10.00m,
                Size=PizzaSize.Large
            });
            order.Pizzas.Add(new Pizza()
            {
                Crust = PizzaCrust.Regular,
                Price = 10.00m,
                Size = PizzaSize.Large
            });

            var finalPrice = pizzaOrderingSystem.ComputePrice(order);

            var expected = 10.00m;
            Assert.AreEqual(expected, finalPrice);
        }

        [TestMethod]
        public void FivePercentOffMoreThanFiftyDollars()
        {           
            decimal largePizzaPrice = 10.00m;
            var order = new PizzaOrder();
            for (var i= 0;i< 6;i++)
            {
                order.Pizzas.Add(new Pizza()
                {
                    Crust = PizzaCrust.Regular,
                    Price = largePizzaPrice,
                    Size = PizzaSize.Large
                });
            }            

            var finalPrice = pizzaOrderingSystem.ComputePrice(order);
            var expected = 57.00m;
            Assert.AreEqual(expected, finalPrice);
        }

        //[TestMethod]
        //public void BuyOneGetOneFreeDiscount()
        //{           
        //   var order = new PizzaOrder();
        //   var price= pizzaOrderingSystem.ComputePrice(order);
        //   Assert.Equals(10.00m, price);
        //}
    }

    
}
