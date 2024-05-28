using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary.Services
{
    public static class CategoryToId
    {
        /// <summary>
        /// The required category input for the Api is numerical.
        /// this methods converts users input to category number. 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static int GetCategoryId(string category)
        {
            switch (category.ToLower())
            {
                case "general knowledge":
                    return 9;
                case "books":
                    return 10;
                case "film":
                    return 11;
                case "music":
                    return 12;
                case "musical & theatres":
                    return 13;
                case "television":
                    return 14;
                case "video games":
                    return 15;
                case "board games":
                    return 16;
                case "science and nature":
                    return 17;
                case "computers":
                    return 18;
                case "mathematics":
                    return 19;
                case "mythology":
                    return 20;
                case "sports":
                    return 21;
                case "geography":
                    return 22;
                case "history":
                    return 23;
                case "politics":
                    return 24;
                case "art":
                    return 25;
                case "celebrities":
                    return 26;
                case "animals":
                    return 27;
                case "vehicles":
                    return 28;
                case "comics":
                    return 29;
                case "gadgets":
                    return 30;
                case "japanese anime & manga":
                    return 31;
                case "cartoon & animation":
                    return 32;
                default:
                    return 9;
            }
        }
    }
}
