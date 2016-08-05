using System.Collections.Generic;
using NUnit.Framework;

namespace ClientFirstPOS
{
    public abstract class FindPriceInCatalogContract
    {
        [Test]
        public void ProductFound()
        {
            Price foundPrice = Price.cents(1250);
            ICatalog catalog = CatalogWith("12345", foundPrice);

            Assert.AreEqual(foundPrice, catalog.FindPrice("12345"));
        }

        [Test]
        public void ProductNotFound()
        {
            Assert.AreEqual(null, CatalogWithout("12345").FindPrice("12345"));
        }

        protected abstract ICatalog CatalogWith(string barcode, Price price);
        protected abstract ICatalog CatalogWithout(string barcode);
    }
}