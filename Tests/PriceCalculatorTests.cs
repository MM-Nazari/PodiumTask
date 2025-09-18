using IceCreamShop.Domain;
using IceCreamShop.Factories;
using IceCreamShop.Orders;
using IceCreamShop.Services;

namespace Tests
{
    /// <summary>
    /// Unit tests for IceCream order calculations.
    /// </summary>
    public class PriceCalculatorTests
    {
            [Fact]
            public void Additive_NoTopping_ReturnsBasePrice()
            {
                var iceCream = IceCreamFactory.Create(Size.Small); 

                var calculator = new AdditivePriceCalculator();

                var order = new Order(iceCream, calculator);

                Assert.Equal(10.00m, order.GetTotalPrice()); // 10
            }

            [Fact]
            public void Additive_Smarties_ReturnsIncreasedPrice()
            {
                var iceCream = IceCreamFactory.Create(Size.Medium);
                iceCream.AddTopping(new Topping(ToppingType.Smarties, 0.10m));

                var calculator = new AdditivePriceCalculator();

                var order = new Order(iceCream, calculator);

                Assert.Equal(22.00m, order.GetTotalPrice()); // 20 * 1.10
            }

            [Fact]
            public void Additive_BothToppings_ReturnsSumPercent()
            {
                var iceCream = IceCreamFactory.Create(Size.Medium);
                iceCream.AddTopping(new Topping(ToppingType.Smarties, 0.10m));
                iceCream.AddTopping(new Topping(ToppingType.Chocolate, 0.20m));

                var calculator = new AdditivePriceCalculator();

                var order = new Order(iceCream, calculator);

                Assert.Equal(26.00m, order.GetTotalPrice()); // 20 * (1 + 0.1 + 0.2)
            }

            [Fact]
            public void Multiplicative_BothToppings_ReturnsMultiplicative()
            {
                var iceCream = IceCreamFactory.Create(Size.Medium);
                iceCream.AddTopping(new Topping(ToppingType.Smarties, 0.10m));
                iceCream.AddTopping(new Topping(ToppingType.Chocolate, 0.20m));

                var calculator = new MultiplicativePriceCalculator();

                var order = new Order(iceCream, calculator);

                Assert.Equal(26.40m, order.GetTotalPrice()); // 20 * 1.1 * 1.2 = 26.4
            }
    }
}
