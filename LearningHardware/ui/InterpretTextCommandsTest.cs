using System.IO;
using Moq;
using NUnit.Framework;

namespace LearningHardware.ui
{
    class InterpretTextCommandsTest
    {
        [Test]
        public void zero()
        {
            Mock<IBarcodeScannedListener> barcodeScannedListener = new Mock<IBarcodeScannedListener>();

            new TextCommandInterpreter(barcodeScannedListener.Object).process(
                new StringReader(""));

            barcodeScannedListener.Verify(x => x.onBarcode(""), Times.Never());
        }

        [Test]
        public void oneBarcode()
        {
            Mock<IBarcodeScannedListener> barcodeScannedListener = new Mock<IBarcodeScannedListener>();

            new TextCommandInterpreter(barcodeScannedListener.Object).process(
                new StringReader("::barcode::\n"));

            barcodeScannedListener.Verify(x => x.onBarcode("::barcode::"), Times.Once);
        }
    }

    public interface IBarcodeScannedListener
    {
        void onBarcode(string barcode);
    }

    public class TextCommandInterpreter
    {
        private IBarcodeScannedListener barcodeScannedListener;

        public TextCommandInterpreter(IBarcodeScannedListener barcodeScannedListener)
        {
            this.barcodeScannedListener = barcodeScannedListener;
        }

        public void process(StringReader reader)
        {
            string line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line))
                barcodeScannedListener.onBarcode(line);
        }
    }
}
