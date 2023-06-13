using System;
using System.Threading;
using WindowsInput;

namespace Spammer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make an inputsimulator instance
            InputSimulator inp = new InputSimulator();

            while (true)
            {
                Console.WriteLine("What do you want?" +
                "\n(1) The spam depends on input" +
                "\n(2) Just spam it");
                Console.Write("Your choice [ 1 | 2 ] -> ");
                bool convertable = int.TryParse(Console.ReadLine(), out int choice);
                if (!convertable)
                {
                    throw new Exception("Invalid Input");
                }
                else
                {
                    switch (choice)
                    {
                        case 1: dependsOnInput(inp); break;
                        case 2: justSpamIt(inp); break;
                        case -1: return;
                        default: Console.WriteLine("Invalid Input"); Console.Clear(); break;
                    }
                }
                Console.WriteLine("\nPress enter to back");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void dependsOnInput(InputSimulator inp)
        {
            //ask user input
            Console.Write("\nInput something: ");
            string nullString = Console.ReadLine();
            string[] EmptyArray = new string[nullString.Length];
            for (var i = 0; i < nullString.Length; i++)
            {
                EmptyArray[i] += nullString[i];
            }

            //count down code
            countDown();

            for (var i = 0; i < EmptyArray.Length; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    inp.Keyboard.TextEntry(EmptyArray[j] + " ");
                    Thread.Sleep(200);
                }
                inp.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN); //to press enter on the keyboard
                Thread.Sleep(200);
            }

            var length_helper = EmptyArray.Length - 1;
            for (var i = 1; i < EmptyArray.Length; i++)
            {
                for (var j = 0; j < length_helper; j++)
                {
                    inp.Keyboard.TextEntry(EmptyArray[j] + " ");
                    Thread.Sleep(200);
                }
                length_helper -= 1;
                //to press enter on the keyboard
                inp.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(200);
            }

            Console.WriteLine("\nDone!!!\n`");
        }

        public static void justSpamIt(InputSimulator inp)
        {
            Console.Write("\nWhat message do you want to send -> ");
            String msg = Console.ReadLine();
            Console.Write("How many message do you want to send -> ");
            bool convertable = int.TryParse(Console.ReadLine(), out int amountOfInput);
            if (!convertable)
            {
                Console.WriteLine("Invalid input");
                justSpamIt(inp);
            }

            countDown();
            for (int i = 0; i < amountOfInput; i++)
            {
                inp.Keyboard.TextEntry(msg);
                Thread.Sleep(100);
                inp.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            }

            Console.WriteLine("\nDone!!!\n");
        }

        public static void countDown()
        {
            Console.Write("\nStarts in ");
            int x = 3;
            for (var i = 0; i < 3; i++)
            {
                Console.Write(x + " ");
                x--;
                Thread.Sleep(700);
            }
        }
    }
}
