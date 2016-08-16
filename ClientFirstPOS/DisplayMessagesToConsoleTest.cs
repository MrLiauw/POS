using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using VirtualPointOfSaleTerminal;

namespace ClientFirstPOS
{
    [TestFixture]
    public class DisplayMessagesToConsoleTest
    {
        private TextWriter _productionSystemOut;

        [SetUp]
        public void rememberConsoleOut()
        {
            _productionSystemOut = Console.Out;
        }


        [TearDown]
        public void restoreConsoleOut()
        {
            Console.SetOut(_productionSystemOut);
        }

        [Test]
        public void ProductNotFound()
        {
            StringWriter canvas = new StringWriter();
            Console.SetOut(canvas);

            new EnglishLanguageConsoleDisplay().DisplayProductNotFoundMessage("5324234");

            Assert.AreEqual(new List<string>() { "Product not found for 5324234" }, 
                TextUtilities.Lines(canvas.ToString()));
        }

        [Test]
        public void EmptyBarcode()
        {
            StringWriter canvas = new StringWriter();
            Console.SetOut(canvas);

            new EnglishLanguageConsoleDisplay().DisplayEmptyBarcodeMessage();

            Assert.AreEqual(new List<string>() { "Scanning error: empty barcode" },
                TextUtilities.Lines(canvas.ToString()));
        }

        [Test]
        public void MultipleMessages()
        {
            StringWriter canvas = new StringWriter();
            Console.SetOut(canvas);

            var consoleDisplay = new EnglishLanguageConsoleDisplay();
            consoleDisplay.DisplayEmptyBarcodeMessage();
            consoleDisplay.DisplayProductNotFoundMessage("87238947");
            consoleDisplay.DisplayEmptyBarcodeMessage();
            consoleDisplay.DisplayProductNotFoundMessage("9284324");

            Assert.AreEqual(new List<string>()
            {
                "Scanning error: empty barcode",
                "Product not found for 87238947",
                "Scanning error: empty barcode",
                "Product not found for 9284324"
            },
                TextUtilities.Lines(canvas.ToString()));
        }
    }
}