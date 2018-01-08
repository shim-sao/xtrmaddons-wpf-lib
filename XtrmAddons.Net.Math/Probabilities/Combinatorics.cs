using System.Collections.Generic;
using System.Threading.Tasks;

namespace XtrmAddons.Net.Math.Probabilities
{
    /// <summary>
    /// <para>Class XtrmAddons Net Math Probabilities Combinatorics.</para>
    /// </summary>
    public static class Combinatorics
    {
        /// <summary>
        /// Method to get a factorial for a number n.
        /// </summary>
        /// <param name="n">A number n</param>
        /// <returns>The factorial result.</returns>
        public static double Factorial(long n)
        {
            if (n < 2)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        /// <summary>
        /// Method to get a count of combinations.
        /// </summary>
        /// <param name="n">A number n of choices.</param>
        /// <param name="p">A number p of rods.</param>
        /// <returns>The number of combinations without double.</returns>
        public static double CombinationsCount(long n, long p)
        {
            return Factorial(n) / (Factorial(p) * Factorial(n - p));
        }

        /// <summary>
        /// Method to get a count of combinations asynchronous.
        /// </summary>
        /// <param name="n">A number n of choices.</param>
        /// <param name="p">A number p of rods.</param>
        /// <returns>The number of combinations without double.</returns>
        public static async Task<double> CombinationsCountAsync(long n, long p)
        {
            return await Task.Run(() =>
            {
                return CombinationsCount(n, p);
            });
        }

        /// <summary>
        /// Method to get a list of all available combinations of p elements in an array of n elements. 
        /// </summary>
        /// <param name="array">An array.</param>
        /// <param name="startingIndex">The starting index for combination.</param>
        /// <param name="combinationLenght">The lenght of the combination of elements.</param>
        /// <returns>A list of all available combinations.</returns>
        public static List<List<int>> GetCombinations(int[] array, int startingIndex = 0, int combinationLenght = 2)
        {
            List<List<int>> combinations = new List<List<int>>();
            if (combinationLenght == 2)
            {
                int combinationsListIndex = 0;
                for (int arrayIndex = startingIndex; arrayIndex < array.Length; arrayIndex++)
                {

                    for (int i = arrayIndex + 1; i < array.Length; i++)
                    {

                        // Add new List in the list to hold the new combination
                        combinations.Add(new List<int>());

                        // Add the starting index element from "array"
                        combinations[combinationsListIndex].Add(array[arrayIndex]);
                        while (combinations[combinationsListIndex].Count < combinationLenght)
                        {
                            // Add until we come to the length of the combination
                            combinations[combinationsListIndex].Add(array[i]);
                        }
                        combinationsListIndex++;
                    }

                }

                return combinations;
            }

            List<List<int>> combinationsofMore = new List<List<int>>();
            for (int i = startingIndex; i < array.Length - combinationLenght + 1; i++)
            {
                // Generate combinations of length-1(if length > 2 we enter into recursion)
                combinations = GetCombinations(array, i + 1, combinationLenght - 1);

                // Add the starting index Element in the beginning of each newly generated list
                for (int index = 0; index < combinations.Count; index++)
                {
                    combinations[index].Insert(0, array[i]);
                }

                for (int y = 0; y < combinations.Count; y++)
                {
                    combinationsofMore.Add(combinations[y]);
                }
            }

            return combinationsofMore;
        }

        /// <summary>
        /// Method to get a list of all available combinations of p elements in an array of n elements asynchronously. 
        /// </summary>
        /// <param name="array">An array.</param>
        /// <param name="startingIndex">The starting index for combination.</param>
        /// <param name="combinationLenght">The lenght of the combination of elements.</param>
        /// <returns>A list of all available combinations.</returns>
        public static async Task<List<List<int>>> GetCombinationsAsync(int[] array, int startingIndex = 0, int combinationLenght = 2)
        {
            return await Task.Run(() =>
            {
                return GetCombinations(array, startingIndex, combinationLenght);
            });
        }
    }
}
