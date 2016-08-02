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
            InMemoryCatalog catalog = new InMemoryCatalog(new Dictionary<string, Price>(){
                {
                    "12345", foundPrice
                }});

            Assert.AreEqual(foundPrice, catalog.FindPrice("12345"));

        }

        [Test]
        public void ProductNotFound()
        {
            InMemoryCatalog catalog = new InMemoryCatalog(new Dictionary<string, Price>());

            Assert.AreEqual(null, catalog.FindPrice("12345"));
        }
    }
}