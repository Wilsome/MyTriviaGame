using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary.Interfaces
{
    public interface IUserOutput
    {
        void WriteLine(string value);

        void Clear();

        void TextColor(string text, string color);

        void Write(string value);
    }
}
