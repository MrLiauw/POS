using System.Collections.Generic;

namespace VirtualPointOfSaleTerminal
{
    public class InMemoryCatalog : ICatalog
    {
        private readonly Dictionary<string, Price> _priceByBarCode;

        public InMemoryCatalog(Dictionary<string, Price> priceByBarCode)
        {
            _priceByBarCode = priceByBarCode;
        }

        public Price FindPrice(string barcode)
        {
            Price price;
            if (_priceByBarCode.TryGetValue(barcode, out price))
                return price;
            return null;
        }
    }
}