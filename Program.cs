using IceCreamShop.Domain;
using IceCreamShop.Factories;
using IceCreamShop.Orders;
using IceCreamShop.Services;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("--- Ice Cream Shop ---");
        Console.WriteLine("Select ice cream size:");
        Console.WriteLine("1) Small - 10");
        Console.WriteLine("2) Medium - 20");
        Console.WriteLine("3) Large - 50");
        Console.Write("Enter your choice: ");

        if (!int.TryParse(Console.ReadLine(), out var sizeInput) || !Enum.IsDefined(typeof(Size), sizeInput))
        {
            Console.WriteLine("Invalid input. Exiting...");
            return;
        }

        var size = (Size)sizeInput;
        var iceCream = IceCreamFactory.Create(size);


        Console.Write("Do you want Smarties topping? (y/n): ");
        if (!TryReadYesNo(out var smarties))
        {
            Console.WriteLine("Invalid input for Smarties topping. Exiting...");
            return;
        }

        Console.Write("Do you want Chocolate topping? (y/n): ");
        if (!TryReadYesNo(out var chocolate))
        {
            Console.WriteLine("Invalid input for Chocolate topping. Exiting...");
            return;
        }

        if (smarties)
            iceCream.AddTopping(new Topping(ToppingType.Smarties, 0.10m));
        if (chocolate)
            iceCream.AddTopping(new Topping(ToppingType.Chocolate, 0.20m));

        Console.WriteLine("Choose price calculation mode: ");
        Console.WriteLine("1) Additive percentages");
        Console.WriteLine("2) Multiplicative percentages");
        Console.Write("Enter your choice: ");

        var modeInput = Console.ReadLine();

        IPriceCalculator calculator = modeInput switch
        {
            "1" => new AdditivePriceCalculator(),
            "2" => new MultiplicativePriceCalculator(),
            _ => null
        };

        if (calculator == null)
        {
            Console.WriteLine("Invalid calculation mode. Exiting...");
            return;
        }

        var order = new Order(iceCream, calculator);

        Console.WriteLine("--- Order Summary ---");
        Console.WriteLine(order.GetSummary());
    }

    static bool TryReadYesNo(out bool result)
    {
        var input = Console.ReadLine()?.Trim().ToLowerInvariant();
        if (input == "y" || input == "yes")
        {
            result = true;
            return true;
        }

        if (input == "n" || input == "no")
        {
            result = false;
            return true;
        }

        result = false;
        return false;
    }
}
