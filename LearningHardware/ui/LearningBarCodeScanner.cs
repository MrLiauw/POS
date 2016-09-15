using System;

namespace ClientFirstPOS.ui
{
    class LearningBarCodeScanner
    {
        public static void Main(string[] args)
        {
            string line;
            do
            {
                line = Console.ReadLine();
                Console.WriteLine(line);
            } while (!string.IsNullOrEmpty(line));
        }
    }
}
