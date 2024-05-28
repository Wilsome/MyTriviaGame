using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary
{
    public class Question
    {
        
        public string Category { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public int Value { get; set; } = 0;
        public string Text { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        
        [JsonIgnore]
        public bool IsBooleanQuestion { get; set; }

        // Add a property to identify if the answer is a number or year
        public bool RequiresExactMatch => int.TryParse(CorrectAnswer, out _);
    }
}
