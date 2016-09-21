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

        [Test]
        public void severalBarcodes()
        {
            Mock<IBarcodeScannedListener> barcodeScannedListener = new Mock<IBarcodeScannedListener>();

            new TextCommandInterpreter(barcodeScannedListener.Object).process(
                new StringReader("::barcode 1::\n::barcode 2::\n::barcode 3::\n"));

            barcodeScannedListener.Verify(x => x.onBarcode("::barcode 1::"), Times.Once);
            barcodeScannedListener.Verify(x => x.onBarcode("::barcode 2::"), Times.Once);
            barcodeScannedListener.Verify(x => x.onBarcode("::barcode 3::"), Times.Once);
        }

        [Test]
        public void severalBarcodesInterspresedWithEmptyLines()
        {
            Mock<IBarcodeScannedListener> barcodeScannedListener = new Mock<IBarcodeScannedListener>();

            new TextCommandInterpreter(barcodeScannedListener.Object).process(
                new StringReader("::barcode 1::\n   \n::barcode 2::\n\t\n::barcode 3::\n"));

            barcodeScannedListener.Verify(x => x.onBarcode("::barcode 1::"), Times.Once);
            barcodeScannedListener.Verify(x => x.onBarcode("::barcode 2::"), Times.Once);
            barcodeScannedListener.Verify(x => x.onBarcode("::barcode 3::"), Times.Once);
            barcodeScannedListener.Verify(x => x.onBarcode("   "), Times.Never);
            barcodeScannedListener.Verify(x => x.onBarcode(""), Times.Never);
            barcodeScannedListener.Verify(x => x.onBarcode("\t"), Times.Never);
        }

        [Test]
        public void trimsBarcode()
        {
            Mock<IBarcodeScannedListener> barcodeScannedListener = new Mock<IBarcodeScannedListener>();

            new TextCommandInterpreter(barcodeScannedListener.Object).process(
                new StringReader("\t    ::barcode 1::\t\n   \n"));

            barcodeScannedListener.Verify(x => x.onBarcode("::barcode 1::"), Times.Once);
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
            InterpretCommandsFromTextInput(reader);
        }

        private void InterpretCommandsFromTextInput(StringReader reader)
        {
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                    break;
                if(SanitizeLine(line) == string.Empty)
                    continue;
                InterpretTextCommand(SanitizeLine(line));
            }
        }

        private static string SanitizeLine(string line)
        {
            return line.Trim();
        }

        private void InterpretTextCommand(string line)
        {
            barcodeScannedListener.onBarcode(line);
        }
    }
}
