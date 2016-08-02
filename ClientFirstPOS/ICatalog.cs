namespace ClientFirstPOS
{
    public interface ICatalog
    {
        Price FindPrice(string barcode);
    }
}