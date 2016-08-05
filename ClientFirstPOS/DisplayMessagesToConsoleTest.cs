using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

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

            new ConsoleDisplay().displayProductNotFoundMessage("5324234");

            Assert.AreEqual(new List<string>() { "Product not found for 5324234" }, 
                TextUtilities.Lines(canvas.ToString()));
        }
    }

    public class ConsoleDisplay
    {
        public void displayProductNotFoundMessage(string barcodeNotFound)
        {
            Console.WriteLine(string.Format("Product not found for {0}", barcodeNotFound));
        }
    }
}