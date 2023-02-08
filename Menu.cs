using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Prakticheskaya
{
    internal class Menu
    {
        private int POS;
        private int min;
        private int max;
        public Menu(int pos)
        {
            POS = pos;
            PrintMenuArrows();
        }
        public void Update(int pos, int maxpos, int minpos, bool isUp)
        {
            if (isUp)
            {
                if (pos > maxpos)
                {
                    Console.SetCursorPosition(0, pos - 1);
                    Console.Write("  ");
                }
                else
                {
                    Console.SetCursorPosition(0, pos + 1);
                    Console.Write("  ");
                }
            }
            else
            {
                if (pos < minpos)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                }
                else
                {
                    Console.SetCursorPosition(0, pos - 1);
                    Console.Write("  ");
                }
            }
            POS = pos;

            PrintMenuArrows();
        }
        private void PrintMenuArrows()
        {

            Console.SetCursorPosition(0, POS);
            Console.Write("->");
        }
    }
}
