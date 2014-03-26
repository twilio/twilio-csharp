using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twilio.Api.Tests.Performance
{
    public class ConsoleSpinner
    {
        int counter;
        public ConsoleSpinner()
        {
            counter = 0;
        }
        public void Turn()
        {
            counter++;
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }

            int left = Console.CursorLeft > 0 ? Console.CursorLeft - 1 : Console.CursorLeft;
            int top = Console.CursorTop;

            Console.SetCursorPosition(left, top);
        }
    }
}
