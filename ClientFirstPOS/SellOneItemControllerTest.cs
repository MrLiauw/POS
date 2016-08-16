using Moq;
using NUnit.Framework;
using VirtualPointOfSaleTerminal;

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
            mockCatalog.Setup(c => c.FindPrice("::product found::")).Returns(irrelevantPrice);

            SaleController saleController = new SaleController(mockDisplay.Object, mockCatalog.Object);
            saleController.onBarcode("::product found::");
            mockDisplay.Verify(d=>d.DisplayPrice(irrelevantPrice), Times.Once);
        }

        [Test]
        public void productNotFound()
        {
            Mock<IDisplay> mockDisplay = new Mock<IDisplay>();
            Mock<ICatalog> mockCatalog = new Mock<ICatalog>();
            mockCatalog.Setup(c => c.FindPrice("::product not found::")).Returns((Price) null);

            SaleController saleController = new SaleController(mockDisplay.Object, mockCatalog.Object);
            saleController.onBarcode("::product not found::");
            mockDisplay.Verify(d => d.DisplayProductNotFoundMessage(It.IsRegex(@".\:{1}product not found\:{1}.")), Times.Once);
        }

        [Test]
        public void emptyBarcode()
        {
            Mock<IDisplay> mockDisplay = new Mock<IDisplay>();

            SaleController saleController = new SaleController(mockDisplay.Object, null);
            saleController.onBarcode("");
            mockDisplay.Verify(d => d.DisplayEmptyBarcodeMessage(), Times.Once());
        }
    }
}
