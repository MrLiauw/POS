using System;

namespace ClientFirstPOS
{
    public class ConsoleDisplay : IDisplay
    {
        private string PRODUCT_NOT_FOUND_MESSAGE_TEMPLATE = "Product not found for {0}";
        private string EMPTY_BARCODE_MESSAGE_TEMPLATE = "Scanning error: empty barcode";
        private string PRICE_FOUND_MESSAGE_TEMPLATE = "${0}";

        private void DisplayMessage(string messageTemplate, string placeholderValue = "")
        {
            Render(Merge(messageTemplate, placeholderValue));
        }

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
            DisplayMessage(PRODUCT_NOT_FOUND_MESSAGE_TEMPLATE, barcodeNotFound);
        }

        public void DisplayEmptyBarcodeMessage()
        {
            DisplayMessage(EMPTY_BARCODE_MESSAGE_TEMPLATE);
        }

        public void DisplayPrice(Price price)
        {
            DisplayMessage(PRICE_FOUND_MESSAGE_TEMPLATE, price.DollarValue().ToString("#,##0.00"));
        }
    }
}