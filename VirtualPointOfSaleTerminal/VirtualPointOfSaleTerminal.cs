using System;
using System.Collections.Generic;

namespace VirtualPointOfSaleTerminal
{
    class VirtualPointOfSaleTerminal
    {
        static void Main(string[] args)
        {
            SaleController saleController = new SaleController(
                new EnglishLanguageConsoleDisplay(), 
                new InMemoryCatalog(
                    new Dictionary<string, Price>()
                    {
                        {"12345", Price.cents(795)},
                        {"23456", Price.cents(1250)}
                    }
                    ));

            saleController.onBarcode("12345");
            saleController.onBarcode("23456");
            saleController.onBarcode("99999");
            saleController.onBarcode("");
            Console.Read();
        }
    }
}
