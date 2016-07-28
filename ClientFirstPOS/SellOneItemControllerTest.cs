using Moq;
using NUnit.Framework;

namespace ClientFirstPOS
{
    class SellOneItemControllerTest
    {
        [Test]
        public void productFound()
        {
            Mock<IDisplay> mockDisplay = new Mock<IDisplay>();
            Mock<ICatalog> mockCatalog = new Mock<ICatalog>();
            Price irrelevantPrice = Price.cents(795);
            mockCatalog.Setup(c => c.FindPrice(It.IsAny<string>())).Returns(irrelevantPrice);

            SaleController saleController = new SaleController(mockDisplay.Object, mockCatalog.Object);
            saleController.onBarcode("12345");
            mockDisplay.Verify(d=>d.DisplayPrice(irrelevantPrice), Times.Once);
        }
    }

    public class SaleController
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
            display.DisplayPrice(catalog.FindPrice(barcode));
        }
    }

    public interface IDisplay
    {
        void DisplayPrice(Price cents);
    }

    public interface ICatalog
    {
        Price FindPrice(string barcode);
    }

    public class Price
    {
        public static Price cents(int centsValue)
        {
            return new Price();
        }
    }
}
