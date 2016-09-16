using Moq;
using NUnit.Framework;

namespace LearningHardware.ui
{
    class InterpretTextCommandsTest
    {
        [Test]
        public void zero()
        {
            Mock<BarcodeScannedListener> barcodeScannedListener = new Mock<BarcodeScannedListener>();

            barcodeScannedListener.Verify(x=>x.onBarcode(""), Times.Never());

            new TextCommandInterpreter().process("");
        }
    }

    public interface BarcodeScannedListener
    {
        void onBarcode(string barcode);
    }

    public class TextCommandInterpreter
    {
        public void process(string text)
        {
        }
    }
}
