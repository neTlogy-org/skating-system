using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skating_system
{
    /// <summary>
    /// A struct containing the results of dances passed into the Placement class
    /// Shouldn't be constructed anywhere else
    /// </summary>
    public struct Results
    {
        /// <summary>
        /// A dictionary containing results of individual dances mapped to name of dance as a key
        /// </summary>
        public Dictionary<string, Dictionary<int, int>> individual;
        /// <summary>
        /// Total score accumulated by each pair mapped to the pairs number as a key
        /// </summary>
        public Dictionary<int, int> total;

        public Results(Dictionary<string, Dictionary<int, int>> individual, Dictionary<int, int> total)
        {
            this.total = total;
            this.individual = individual;
        }
    }

    internal class Placement
    {
        /// <summary>
        /// A list of lists of dancers, which represents individual dances
        /// </summary>
        Dictionary<string, Dictionary<int, int[]>> rating;

        /// <summary>
        /// Constructor for the Placement class
        /// </summary>
        /// <param name="rating">A dictionary containing name of dance as key and another dictionary with dancers number as key and array of marks as a value as value</param>
        public Placement(Dictionary<string, Dictionary<int, int[]>> rating)
        {
            this.rating = rating;
        }

        /// <summary>
        /// Constructor for the placement class with usage of the Dance class
        /// </summary>
        /// <param name="dances">Array of Dances</param>
        public Placement(Dance[] dances)
        {
            Dictionary<string, Dictionary<int, int[]>> rating_tmp = new Dictionary<string, Dictionary<int, int[]>>();
            foreach (Dance dance in dances)
            {
                Dictionary<int, int[]> pairs = new Dictionary<int, int[]>();
                for (int i = 0; i < dance.Couples_nums.Length; i++)
                {
                    pairs.Add(dance.Couples_nums[i], dance.Marks[i]);
                }
                rating_tmp.Add(dance.Dance_title, pairs);
            }
            this.rating = rating_tmp;
        }

        /// <summary>
        /// Main method of this class
        /// </summary>
        /// <returns>Dictionary with total score mapped to the Dancers number</returns>
        public Results Evaluate()
        {
            Dictionary<string, Dictionary<int, int>> individual = new Dictionary<string, Dictionary<int, int>>();
            foreach (var dance in rating)
            {
                individual.Add(dance.Key, EvaluateDance(dance.Value));
            }

            Dictionary<int, int> total = new Dictionary<int, int>();
            foreach (var dance in individual)
            {
                foreach (var pair in dance.Value)
                {
                    total.Add(pair.Key, pair.Value);
                }
            }

            return new Results(individual, total);
        }

        /// <summary>
        /// Evaluates a single dance
        /// Can be used outside of class if the right input is guaranteed.
        /// </summary>
        /// <param name="dance">A dance you want to evaluate</param>
        /// <returns>Dictionary with dancers numbers as key with their mark as value</returns>
        static private Dictionary<int, int> EvaluateDance(Dictionary<int, int[]> dance)
        {
            Dictionary<int, int> order = new Dictionary<int, int>();

            int stage = 1;
            while (dance.Count > 0)
            {
                int dancers_number = FindMajority(dance, stage);
                if (dancers_number != -1)
                {
                    order.Add(dancers_number, order.Count + 1);
                    dance.Remove(dancers_number);
                }
                stage++;
            }

            return order;
        }

        /// <summary>
        /// Finds the current best graded Dancer
        /// </summary>
        /// <param name="dance"></param>
        /// <param name="stage"></param>
        /// <returns>Number of dancer or -1 if no Dancer meets the requirements</returns>
        static private int FindMajority(Dictionary<int, int[]> dance, int stage)
        {
            int max_count = 0;
            int dancers_number = -1;

            foreach (var dancer in dance)
            {
                int count = 0;
                foreach (int mark in dancer.Value)
                {
                    if (mark <= stage)
                        count++;
                }

                if (count > max_count)
                {
                    max_count = count;
                    dancers_number = dancer.Key;
                }
            }

            if (max_count >= dance.Count / 2)
            {
                return dancers_number;
            }
            else
            {
                return -1;
            }
        }
    }
}
