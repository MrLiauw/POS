using System.Collections.Generic;
using VirtualPointOfSaleTerminal;

namespace ClientFirstPOS
{
    public class FindPriceInMemoryCatalogTest : FindPriceInCatalogContract
    {
        protected override ICatalog CatalogWith(string barcode, Price price)
        {
            return new InMemoryCatalog(new Dictionary<string, Price>(){
                {"definitely barcode" + barcode, Price.cents(0)},
                {barcode, price},
                {"again definitely not " + barcode, Price.cents(10000000)}
            });
        }

        protected override ICatalog CatalogWithout(string barcodeToAvoid)
        {
            return new InMemoryCatalog(new Dictionary<string, Price>(){
                {
                    "anything but " + barcodeToAvoid, Price.cents(0)
                }});
        }
    }
}