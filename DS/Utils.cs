using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    class Utils
    {
        public static void WriteInput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(input);
            Console.ResetColor();
        }

        public static void WriteOutput(string output)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(output);
            Console.ResetColor();
        }
    }
}
