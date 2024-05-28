﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary.Helpers
{
    /// <summary>
    /// Checks users input for correctness against the correct answer. 
    /// </summary>
    public static class StringSimilarityHelper
    {
        private static readonly int SimilarityThreshold = 2;

        // Calculate Levenshtein Distance
        private static int CalculateLevenshteinDistance(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
                dp[i, 0] = i;
            for (int j = 0; j <= s2.Length; j++)
                dp[0, j] = j;
            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
                }
            }
            return dp[s1.Length, s2.Length];
        }

        // Method to check if two strings are similar
        public static bool AreStringsSimilar(string s1, string s2)
        {
            int distance = CalculateLevenshteinDistance(s1.ToLower(), s2.ToLower());
            return distance <= SimilarityThreshold;
        }
    }
}
