namespace ClientFirstPOS
{
    public class Price
    {
        private readonly int _priceInCents;

        public static Price cents(int centsValue)
        {
            return new Price(centsValue);
        }

        public Price(int priceInCents)
        {
            _priceInCents = priceInCents;
        }

        public decimal DollarValue()
        {
            return (decimal)_priceInCents / 100;
        }
    }
}