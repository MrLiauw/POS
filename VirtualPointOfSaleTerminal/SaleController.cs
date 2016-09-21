namespace VirtualPointOfSaleTerminal
{
    public class SaleController : IBarcodeScannedListener
    {
        private IDisplay display;
        private ICatalog catalog;

        public SaleController(IDisplay display, ICatalog catalog)
        {
            this.display = display;
            this.catalog = catalog;
        }

        public void onBarcode(string barcode)
        {
            if (barcode == string.Empty)
            {
                display.DisplayEmptyBarcodeMessage();
                return;
            }
            Price price = catalog.FindPrice(barcode);
            if(price == null)
                display.DisplayProductNotFoundMessage(barcode);
            else
                display.DisplayPrice(price);
        }
    }
}
