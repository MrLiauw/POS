using System.Collections.Generic;
using NUnit.Framework;

namespace ClientFirstPOS
{
    public class FindPriceInMemoryCatalogTest
    {
        [Test]
        public void ProductFound()
        {
            Price foundPrice = Price.cents(1250);
            ICatalog catalog = CatalogWith("12345", foundPrice);

            Assert.AreEqual(foundPrice, catalog.FindPrice("12345"));

        }

        private static ICatalog CatalogWith(string barcode, Price price)
        {
            return new InMemoryCatalog(new Dictionary<string, Price>(){
                {
                    barcode, price
                }});
        }

        [Test]
        public void ProductNotFound()
        {
            Assert.AreEqual(null, CatalogWithout("12345").FindPrice("12345"));
        }

        private static ICatalog CatalogWithout(string price)
        {
            return new InMemoryCatalog(new Dictionary<string, Price>());
        }
    }
}