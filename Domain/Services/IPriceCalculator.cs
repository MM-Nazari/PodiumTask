using IceCreamShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Services
{
    /// <summary>
    /// Strategy interface for calculating the final price of an order.
    /// </summary>
    public interface IPriceCalculator
    {
        decimal Calculate(IIceCream iceCream);
    }
}
