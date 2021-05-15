using System;

namespace SudokuSolver.Utils
{
    public static class Chalk
    {
        
        /**
         *  +---------+------------+------------+
            |  color  | foreground | background |
            |         |    code    |    code    |
            +---------+------------+------------+
            | black   |     30     |     40     |
            | red     |     31     |     41     |
            | green   |     32     |     42     |
            | yellow  |     33     |     43     |
            | blue    |     34     |     44     |
            | magenta |     35     |     45     |
            | cyan    |     36     |     46     |
            | white   |     37     |     47     |
            +---------+------------+------------+
         */
        
        
        private enum WriteBehaviour
        {
            NoLine,
            Line
        };

        public static void White(string text)
        {
            LogWithColor("\x1b[37m", text, WriteBehaviour.NoLine);
        }
        
        public static void WhiteLine(string text)
        {
            LogWithColor("\x1b[37m", text);
        }

        public static void Red(string text)
        {
            LogWithColor("\x1b[31m", text, WriteBehaviour.NoLine);
        }
        public static void RedLine(string text)
        {
            LogWithColor("\x1b[31m", text);
        }

        public static void Green(string text)
        {
            LogWithColor("\x1b[32m", text, WriteBehaviour.NoLine);
        }
        public static void GreenLine(string text)
        {
            LogWithColor("\x1b[32m", text);
        }

        public static void Blue(string text)
        {
            LogWithColor("\x1b[34m", text, WriteBehaviour.NoLine);
        }
        public static void BlueLine(string text)
        {
            LogWithColor("\x1b[34m", text);
        }

        public static void Magenta(string text)
        {
            LogWithColor("\x1b[35m", text, WriteBehaviour.NoLine);
        }
        public static void MagentaLine(string text)
        {
            LogWithColor("\x1b[35m", text);
        }

        public static void Yellow(string text)
        {
            LogWithColor("\x1b[33m", text, WriteBehaviour.NoLine);
        }
        public static void YellowLine(string text)
        {
            LogWithColor("\x1b[33m", text);
        }

        private static void LogWithColor(string color, string text, WriteBehaviour line = WriteBehaviour.Line)
        {
            Console.Write(color);
            Console.Write(text);
            Console.Write("\x1b[0m");
            
            if (line == WriteBehaviour.Line)
            {
                Console.WriteLine();
            }
            
            
        }
        
    }
}