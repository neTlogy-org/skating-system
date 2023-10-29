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
        public Dictionary<string, Dictionary<int, float>> individual;
        /// <summary>
        /// Total score accumulated by each pair mapped to the pairs number as a key
        /// </summary>
        public Dictionary<int, float> total;
        public Dictionary<int, Dictionary<string, string>> rating;

        public Dictionary<int, float> placement;

        public Results(Dictionary<string, Dictionary<int, float>> individual, Dictionary<int, float> total, Dictionary<int, Dictionary<string, string>> rating, Dictionary<int, float> placement)
        {
            this.total = total;
            this.individual = individual;
            this.rating = rating;
            this.placement = placement;
        }
    }

    internal class Placement
    {
        /// <summary>
        /// A list of lists of dancers, which represents individual dances
        /// </summary>
        Dictionary<string, Dictionary<int, int[]>> rating;
        int number_of_judges;

        /// <summary>
        /// Constructor for the Placement class
        /// </summary>
        /// <param name="rating">A dictionary containing name of dance as key and another dictionary with dancers number as key and array of marks as a value as value</param>
        public Placement(Dictionary<string, Dictionary<int, int[]>> rating, int number_of_judges)
        {
            this.number_of_judges = number_of_judges;
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
            this.number_of_judges = dances[0].JudgeCnt;
        }

        /// <summary>
        /// Main method of this class
        /// </summary>
        /// <returns>Dictionary with total score mapped to the Dancers number</returns>
        public Results Evaluate()
        {
            Dictionary<string, Dictionary<int, float>> individual = new Dictionary<string, Dictionary<int, float>>();
            Dictionary<int, Dictionary<string, string>> rating_tmp = new Dictionary<int, Dictionary<string, string>>();
            foreach (var dance in rating)
            {
                foreach (var pair in dance.Value)
                {
                    if (!rating_tmp.ContainsKey(pair.Key))
                    {
                        rating_tmp.Add(pair.Key, new Dictionary<string, string>());
                    }

                    string tmp = "";
                    foreach (int mark in pair.Value)
                    {
                        tmp += mark;
                    }
                    rating_tmp[pair.Key].Add(dance.Key, tmp);
                }

                individual.Add(dance.Key, EvaluateDance(dance.Value));
            }

            Dictionary<int, float> total = new Dictionary<int, float>();
            foreach (var dance in individual)
            {
                foreach (var pair in dance.Value)
                {
                    if (!total.TryAdd(pair.Key, pair.Value))
                    {
                        total[pair.Key] += pair.Value;
                    }
                }
            }

            Dictionary<int, float> placement = new Dictionary<int, float>();
            Dictionary<int, List<int>> collisions = new Dictionary<int, List<int>>();
            var ordered = total.OrderBy(x => x.Value).ToList();
            for (int i = 0; i < ordered.Count - 1; i++)
            {
                if (ordered[i].Value == ordered[i + 1].Value)
                {
                    if (!collisions.TryAdd(i + 1, new List<int> { ordered[i].Key, ordered[i + 1].Key }))
                    {
                        collisions[i + 1].Add(ordered[i + 1].Key);
                    }
                    i++;
                }
            }

            // Rule 10
            Dictionary<int, Dictionary<string, float>> individual_by_pairs = new Dictionary<int, Dictionary<string, float>>();
            foreach (var dance in individual)
            {
                foreach (var pair in dance.Value)
                {
                    if (!individual_by_pairs.TryAdd(pair.Key, new Dictionary<string, float> { { dance.Key, pair.Value } }))
                    {
                        individual_by_pairs[pair.Key].Add(dance.Key, pair.Value);
                    }
                }
            }

            if (collisions.Count == 0)
            {
                for (int i = 0; i < ordered.Count; i++)
                {
                    placement.Add(ordered[i].Key, i + 1);
                }
            }
            else
            {
                foreach (var collision in collisions)
                {
                    for (int i = placement.Count; i < collision.Key; i++)
                    {
                        placement.Add(ordered[i].Key, placement.Count + 1);
                    }
                    Dictionary<int, List<float>> individual_by_pairs_only_colliding = new Dictionary<int, List<float>>();
                    foreach (int pair in collision.Value)
                    {
                        individual_by_pairs_only_colliding.Add(pair, individual_by_pairs[pair].Values.ToList());
                    }
                    while (collision.Value.Count > 0)
                    {
                        Dictionary<int, int> dancers_numbers = FindMajority(individual_by_pairs_only_colliding, collision.Key);
                        if (dancers_numbers.Count == 1)
                        {
                            placement.Add(dancers_numbers.Keys.First(), placement.Count + 1);
                            collision.Value.Remove(dancers_numbers.Keys.First());
                        }
                        // Rule 10b
                        else
                        {
                            int lowest_sum = dancers_numbers.Values.First();
                            List<int> same_sums = new List<int>();
                            foreach (var pair in dancers_numbers)
                            {
                                if (pair.Value < lowest_sum)
                                {
                                    same_sums = new List<int> { pair.Key };
                                }
                                else if (pair.Value == lowest_sum)
                                {
                                    same_sums.Add(pair.Key);
                                }
                            }

                            if (same_sums.Count == 1)
                            {
                                placement.Add(same_sums.First(), placement.Count + 1);
                            }
                            else
                            {
                                // Rule 11
                            }
                        }
                    }
                }
                for (int i = placement.Count; i < ordered.Count; i++)
                {
                    placement.Add(ordered[i].Key, placement.Count + 1);
                }
            }

            return new Results(individual, total, rating_tmp, placement);
        }

    /// <summary>
    /// Evaluates a single dance
    /// Can be used outside of class if the right input is guaranteed.
    /// </summary>
    /// <param name="dance">A dance you want to evaluate</param>
    /// <returns>Dictionary with dancers numbers as key with their mark as value</returns>
        private Dictionary<int, float> EvaluateDance(Dictionary<int, int[]> dance)
        {
            Dictionary<int, float> order = new Dictionary<int, float>();

            int stage = 1;
            while (dance.Count > 0)
            {
                // TODO: Check for rule 7a
                List<int> dancers_numbers = FindMajority(dance, stage);
                if (dancers_numbers.Count != 0)
                {
                    int total = 0;
                    for (int i = 1; i <= dancers_numbers.Count; i++)
                    {
                        total += order.Count + i;
                    }
                    float placement = total / dancers_numbers.Count;

                    foreach (int dancers_number in dancers_numbers)
                    {
                        order.Add(dancers_number, placement);
                        dance.Remove(dancers_number);
                    }
                    stage = 1;
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
        private List<int> FindMajority(Dictionary<int, int[]> dance, int stage)
        {
            int max_count = 0;
            List<int> dancers_numbers = new List<int>();

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
                    dancers_numbers = new List<int> { dancer.Key };
                }
                else if (count == max_count)
                {
                    dancers_numbers.Add(dancer.Key);
                }
            }

            if (max_count > number_of_judges / 2)
            {
                return dancers_numbers;
            }
            else
            {
                return new List<int>();
            }
        }

        private Dictionary<int, int> FindMajority(Dictionary<int, List<float>> dancer, int place)
        {
            int max_count = 0;
            Dictionary<int, int> dancers_numbers = new Dictionary<int, int>();

            foreach (var dance in dancer)
            {
                int count = 0;
                int sum = 0;
                foreach (int mark in dance.Value)
                {
                    if (mark <= place)
                    {
                        count++;
                        sum += mark;
                    }
                }

                if (count > max_count)
                {
                    max_count = count;
                    dancers_numbers = new Dictionary<int, int> { { dance.Key, sum } };
                }
                else if (count == max_count)
                {
                    dancers_numbers.Add(dance.Key, sum);
                }
            }

            return dancers_numbers;
        }
    }
}
