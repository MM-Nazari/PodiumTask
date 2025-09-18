using IceCreamShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Factories
{
    /// <summary>
    /// Factory class for creating ice cream objects of different sizes.
    /// </summary>
    public static class IceCreamFactory
    {
        public static IceCream Create(Size size)
        {
            return size switch
            {
                Size.Small => new IceCream(Size.Small, 10m),
                Size.Medium => new IceCream(Size.Medium, 20m),
                Size.Large => new IceCream(Size.Large, 50m),
                _ => throw new ArgumentOutOfRangeException(nameof(size))
            };
        }
    }
}
