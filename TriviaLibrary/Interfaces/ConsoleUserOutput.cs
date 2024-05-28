using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary.Interfaces
{
    public class ConsoleUserOutput : IUserOutput
    {
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Writes inputed string to inputed color on the console. 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public void TextColor(string text, string color)
        {
            {
                ConsoleColor consoleColor;

                // Convert the string color to ConsoleColor
                if (Enum.TryParse(color, true, out consoleColor))
                {
                    Console.ForegroundColor = consoleColor;
                }
                else
                {
                    // If the color is not valid, default to white
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(text);
                Console.ResetColor(); // Reset the text color to default
            }
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }


    }
}
