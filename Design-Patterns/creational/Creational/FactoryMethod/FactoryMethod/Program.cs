// See https://aka.ms/new-console-template for more information
using FactoryMethod;

Console.WriteLine("Factory Method");

var factories = new List<DiscountFactory>
{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("USA")
};

foreach(var factory in factories)
{
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percent => {discountService.DiscountPercentage} from => {discountService}");
}
