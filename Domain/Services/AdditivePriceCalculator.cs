using IceCreamShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Services
{
    /// <summary>
    /// Calculates price by summing the percentage increases of toppings.
    /// </summary>
    public class AdditivePriceCalculator : IPriceCalculator
    {
        public decimal Calculate(IIceCream iceCream)
        {
            if (iceCream == null)
            {
                throw new ArgumentNullException(nameof(iceCream));
            }

            var sumPercent = iceCream.Toppings.Sum(t => t.Percentage);

            return Decimal.Round(iceCream.BasePrice * (1 + sumPercent), 2);
        }
    }
}
