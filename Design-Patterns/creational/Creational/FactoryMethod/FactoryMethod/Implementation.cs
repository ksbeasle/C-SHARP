using System;


namespace FactoryMethod
{
    /// <summary>
    /// Product -- base
    /// </summary>
    public abstract class DiscountService
    {
        // used by client
        public abstract int DiscountPercentage { get; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }

    /// <summary>
    /// Concrete product for a country discount
    /// </summary>
    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryId;

        public CountryDiscountService(string countryId)
        {
            _countryId = countryId;
        }

        public override int DiscountPercentage
        {
            get
            {
                switch (_countryId)
                {
                    case "USA":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }

    /// <summary>
    /// Concrete product for a code discount
    /// </summary>
    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _code;

        public CodeDiscountService(Guid code)
        {
            _code = code;
        }

        public override int DiscountPercentage
        {
            get
            {
                // Some check to make sure the dicsount code hasn't already been used
                return 15;
            }

        }
    }

    /// <summary>
    /// Creator base class for Discount services -- Factory
    /// </summary>
    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    /// <summary>
    /// Concrete creator factory for country discount service
    /// </summary>
    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _countryId;
        public CountryDiscountFactory(string countryId)
        {
            _countryId = countryId;
        }
        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryId);
        }
    }

    /// <summary>
    /// Concrete creator factory for code discount service
    /// </summary>
    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;
        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }
        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }
}
