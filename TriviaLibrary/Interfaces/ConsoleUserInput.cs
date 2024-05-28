using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary.Interfaces
{
    public class ConsoleUserInput : IUserInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
