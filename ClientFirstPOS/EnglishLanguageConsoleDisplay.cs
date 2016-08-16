using System;
using VirtualPointOfSaleTerminal;

namespace ClientFirstPOS
{
    public class EnglishLanguageConsoleDisplay : IDisplay
    {
        private string PRODUCT_NOT_FOUND_MESSAGE_TEMPLATE = "Product not found for {0}";
        private string EMPTY_BARCODE_MESSAGE_TEMPLATE = "Scanning error: empty barcode";
        private string PRICE_FOUND_MESSAGE_TEMPLATE = "${0}";

        private static void Render(string text)
        {
            Console.WriteLine(text);
        }

        private static string Merge(string messageTemplate, string placeholderValue)
        {
            return string.Format(
                messageTemplate, placeholderValue);
        }

        public void DisplayProductNotFoundMessage(string barcodeNotFound)
        {
            Render(Merge(PRODUCT_NOT_FOUND_MESSAGE_TEMPLATE, barcodeNotFound));
        }

        public void DisplayEmptyBarcodeMessage()
        {
            Render(Merge(EMPTY_BARCODE_MESSAGE_TEMPLATE, ""));
        }

        public void DisplayPrice(Price price)
        {
            Render(Merge(PRICE_FOUND_MESSAGE_TEMPLATE, price.DollarValue().ToString("#,##0.00")));
        }
    }
}