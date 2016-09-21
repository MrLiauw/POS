using System;
using System.Collections.Generic;
using System.IO;

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

            new TextCommandInterpreter(saleController).process(new StringReader("12345\n23456\n99999"));
            Console.Read();
        }
    }
}
