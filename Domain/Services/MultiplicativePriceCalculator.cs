using IceCreamShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Services
{
    /// <summary>
    /// Calculates price by applying toppings as multiplicative percentages.
    /// </summary>
    public class MultiplicativePriceCalculator : IPriceCalculator
    {
        public decimal Calculate(IIceCream iceCream)
        {
            if (iceCream == null)
            {
                throw new ArgumentNullException(nameof(iceCream));
            }

            decimal multiplier = 1m;

            foreach (var t in iceCream.Toppings)
                multiplier *= (1 + t.Percentage);

            return Decimal.Round(iceCream.BasePrice * multiplier, 2);
        }
    }
}
