namespace VirtualPointOfSaleTerminal
{
    public interface ICatalog
    {
        Price FindPrice(string barcode);
    }
}