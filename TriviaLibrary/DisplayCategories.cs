using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaLibrary.Interfaces;

namespace TriviaLibrary
{
    public class DisplayCategories(IUserOutput userOutput)
    {
        private readonly List<string> categories =
            [
                "General Knowledge",
                "Books",
                "Film",
                "Music",
                "Musical & Theatres",
                "Television",
                "Video Games",
                "Board Games",
                "Science and Nature",
                "Computers",
                "Mathematics",
                "Mythology",
                "Sports",
                "Geography",
                "History",
                "Politics",
                "Art",
                "Celebrities",
                "Animals",
                "Vehicles",
                "Comics",
                "Gadgets",
                "Japanese Anime & Manga",
                "Cartoon & Animation",

            ];

        /// <summary>
        /// Displays the list of caterogies
        /// </summary>
        public void GetCategories()
        {
            foreach (string category in categories)
            {
                Console.WriteLine(category);
            }
            Console.WriteLine();
            Console.WriteLine("Enter a Category: ");
        }
    }
}
