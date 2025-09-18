using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Domain
{
    /// <summary>
    /// Represents an ice cream with a specific size, base price, and optional toppings.
    /// </summary>
    public class IceCream : IIceCream
    {
        private readonly List<Topping> _toppings = new List<Topping>();

        public Size Size { get; }
        public decimal BasePrice { get; }
        public IReadOnlyList<Topping> Toppings => _toppings.AsReadOnly();

        public IceCream(Size size, decimal basePrice)
        {
            Size = size;
            BasePrice = basePrice;
        }

        public void AddTopping(Topping topping)
        {
            if (topping == null)
            {
                throw new ArgumentNullException(nameof(topping));
            }

            _toppings.Add(topping);
        }

        public string GetDescription()
        {
            var toppingsDesc = Toppings.Any() ? string.Join(", ", Toppings.Select(t => t.ToString())) : "(no toppings)";
            return $"Size: {Size}, Base price: {BasePrice:C}, Toppings: {toppingsDesc}";
        }
    }
}
