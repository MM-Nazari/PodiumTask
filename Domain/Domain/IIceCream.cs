using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Domain
{
    /// <summary>
    /// Defines the contract for ice cream objects (size, price, toppings).
    /// </summary>
    public interface IIceCream
    {
        Size Size { get; }
        decimal BasePrice { get; }
        IReadOnlyList<Topping> Toppings { get; }
        string GetDescription();
    }
}
