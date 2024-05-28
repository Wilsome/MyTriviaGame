using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary
{
    /// <summary>
    /// Keeps track of players information. 
    /// </summary>
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; } = 0;

        public bool AnsweredCorrectly { get; set; } = false;

    }
}
