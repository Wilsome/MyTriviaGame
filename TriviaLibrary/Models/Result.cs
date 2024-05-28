using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary.Models
{
    public class Result
    {
        public string Difficulty { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; } = string.Empty;
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

    }
}
