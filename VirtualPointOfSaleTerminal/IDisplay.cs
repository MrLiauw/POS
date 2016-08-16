namespace VirtualPointOfSaleTerminal
{
    public interface IDisplay
    {
        void DisplayPrice(Price cents);
        void DisplayProductNotFoundMessage(string message);
        void DisplayEmptyBarcodeMessage();
    }
}