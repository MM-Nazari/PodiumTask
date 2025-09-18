using IceCreamShop.Domain;
using IceCreamShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Orders
{
    /// <summary>
    /// Represents a customer's ice cream order and provides summary and pricing.
    /// </summary>
    public class Order
    {
        private readonly IIceCream _iceCream;
        private readonly IPriceCalculator _priceCalculator;

        public Order(IIceCream iceCream, IPriceCalculator priceCalculator)
        {
            _iceCream = iceCream ?? throw new ArgumentNullException(nameof(iceCream));
            _priceCalculator = priceCalculator ?? throw new ArgumentNullException(nameof(priceCalculator));
        }

        public decimal GetTotalPrice() => _priceCalculator.Calculate(_iceCream);

        public string GetSummary()
        {
            return $"{_iceCream.GetDescription()}\n Final price: {GetTotalPrice():C}";
        }

    }
}
