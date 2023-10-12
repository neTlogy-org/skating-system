using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skating_system
{
    struct Dancer
    {
        public readonly int[] score;
        public readonly int starting_number;

        /// <summary>
        /// Constructor for the Dancer class
        /// </summary>
        /// <param name="score">Array of scores achieved by this dancer</param>
        /// <param name="starting_number">The starting number of dancer</param>
        public Dancer(int[] score, int starting_number)
        {
            this.score = score;
            this.starting_number = starting_number;
        }
    }

    internal class Placement
    {
        // tance, porotce - sloupec, tanecnik - radek
        /// <summary>
        /// A list of lists of dancers, which represents individual dances
        /// </summary>
        List<List<Dancer>> rating;
        List<Dictionary<string, Dictionary<int, int[]>>> rating_tmp;

        /// <summary>
        /// Constructor for the Placement class
        /// </summary>
        /// <param name="rating">A List containing another List of Dancers for each dance</param>
        public Placement(List<List<Dancer>> rating)
        {
            this.rating = rating;
        }

        public Placement(Dance[] dances)
        {
            // TODO:

            List<Dictionary<string, Dictionary<int, int[]>>> rating_tmp = new List<Dictionary<string, Dictionary<int, int[]>>>();
            foreach (Dance dance in dances)
            {
                Dictionary<int, int[]> pairs = new Dictionary<int, int[]>();
                for (int i = 0; i < dance.Couples_nums.Length; i++)
                {
                    pairs.Add(dance.Couples_nums[i], dance.Marks[i]);
                }
                rating_tmp.Add(new Dictionary<string, Dictionary<int, int[]>>{ { dance.Dance_title, pairs } });
            }
            this.rating_tmp = rating_tmp;
        }

        /// <summary>
        /// Main method of this class
        /// </summary>
        /// <returns>Dictionary with total skore mapped to the Dancers number</returns>
        public Dictionary<int, int> Evaluate()
        {
            List<List<int>> results = new List<List<int>>();
            for (int i = 0; i < rating.Count; i++)
            {
                results.Add(EvaluateDance(rating[i]));
            }

            Dictionary<int, int> final_results = new Dictionary<int, int>();
            for (int i = 0; i < results.Count; i++)
            {
                for (int j = 0; j < results[i].Count; j++)
                {
                    int val;
                    if (final_results.TryGetValue(results[i][j], out val))
                    {
                        final_results[results[i][j]] = val + j + 1;
                    }
                    else
                    {
                        final_results.Add(results[i][j], j + 1);
                    }
                }
            }

            return final_results;
        }

        /// <summary>
        /// Evaluates a single dance
        /// Can be used outside of class if the right input is guaranteed.
        /// </summary>
        /// <param name="dance">A dance you want to evaluate</param>
        /// <returns>List of dancers numbers ordered by their mark</returns>
        static private List<int> EvaluateDance(List<Dancer> dance)
        {
            List<int> order = new List<int>();

            int stage = 1;
            while (dance.Count > 0)
            {
                int i = FindMajority(dance, stage);
                if (i >= 0)
                {
                    order.Add(dance[i].starting_number);
                    dance.RemoveAt(i);
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
        /// <returns>Index of dancer or -1 if no Dancer meets the requirements</returns>
        static private int FindMajority(List<Dancer> dance, int stage)
        {
            int max_count = 0, index = 0;

            for (int i = 0; i < dance.Count; i++)
            {
                int count = 0;
                foreach (int mark in dance[i].score)
                {
                    if (mark <= stage)
                    {
                        count++;
                    }
                }

                if (count > max_count)
                {
                    max_count = count;
                    index = i;
                }
            }

            if (max_count >= dance.Count / 2)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }
    }
}
