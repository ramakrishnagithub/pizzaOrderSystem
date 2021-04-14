namespace PizzaOrderingSystem.Lib
{
    public class Pizza
    {
        public PizzaCrust Crust { get; set; }
        public decimal Price { get; set; }
        public PizzaSize Size { get; set; }
    }
}