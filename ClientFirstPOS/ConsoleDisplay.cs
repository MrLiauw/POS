using System;

namespace ClientFirstPOS
{
    public class ConsoleDisplay
    {
        public void displayProductNotFoundMessage(string barcodeNotFound)
        {
            Console.WriteLine(
                string.Format("Product not found for {0}", barcodeNotFound));
        }

        internal void displayEmptyBarcodeMessage()
        {
            Console.WriteLine(string.Format("Scanning error: empty barcode"));
        }

        public void displayPrice(Price price)
        {
            decimal priceInDollars = price.PriceInDollars();
            Console.WriteLine(
                string.Format("${0}", priceInDollars.ToString("#,##0.00")));
        }
    }
}