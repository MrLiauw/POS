using System.IO;

namespace VirtualPointOfSaleTerminal
{
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