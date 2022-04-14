using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Abstract Factory -- Describes how to create a family of related abstract products
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

    /// <summary>
    /// Concrete Factory implementaion
    /// </summary>
    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostService();
        }
    }

    /// <summary>
    /// Concrete Factory implementaion
    /// </summary>
    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostService();
        }
    }

    /// <summary>
    /// Abstract Product -- contract
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    /// <summary>
    /// Concrete product implementation
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    /// <summary>
    /// Concrete product implementation
    /// </summary>
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    /// <summary>
    /// Abstract Product -- contract
    /// </summary>
    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// Concrete product implementation
    /// </summary>
    public class BelgiumShippingCostService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// Concrete product implementation
    /// </summary>
    public class FranceShippingCostService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }

    /// <summary>
    /// Client
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;

        // Constructor
        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
            _orderCosts = 200;
        }

        public void CalculateCost()
        {
            Console.WriteLine($"Total costs = {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
        }
    }

}
