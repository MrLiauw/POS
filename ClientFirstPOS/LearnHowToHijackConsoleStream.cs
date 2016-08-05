using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ClientFirstPOS
{
    class LearnHowToHijackConsoleStream
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
        public void singleLineOfText()
        {
            StringWriter canvas = new StringWriter();
            Console.SetOut(canvas);

            Console.WriteLine("Hello, world.");
            Assert.AreEqual(new List<string>(){"Hello, world."}, TextUtilities.Lines(canvas.ToString())); 
        }

        [Test]
        public void multiLinesOfText()
        {
            StringWriter canvas = new StringWriter();
            Console.SetOut(canvas);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Line " + i);
            }

            Assert.AreEqual(new List<string>() { "Line 1", "Line 2", "Line 3", "Line 4", "Line 5" }, TextUtilities.Lines(canvas.ToString())); 
        }
    }
}
