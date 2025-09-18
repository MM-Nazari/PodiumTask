using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Domain
{
    /// <summary>
    /// Represents a topping that can be added to an ice cream (e.g., Smarties, Chocolate).
    /// </summary>
    public sealed class Topping
    {
        public ToppingType Type { get; }
        public decimal Percentage { get; }

        public Topping(ToppingType type, decimal percentage)
        {
            Type = type;
            Percentage = percentage;
        }

        public override string ToString() => Type.ToString();
    }
}
