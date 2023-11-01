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

        public Dictionary<int, int> placement;

        public Results(Dictionary<string, Dictionary<int, float>> individual, Dictionary<int, float> total, Dictionary<int, Dictionary<string, string>> rating, Dictionary<int, int> placement)
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
        Dictionary<string, Dictionary<int, int[]>> rating_copy;
        int number_of_judges;

        /// <summary>
        /// Constructor for the Placement class
        /// </summary>
        /// <param name="rating">A dictionary containing name of dance as key and another dictionary with dancers number as key and array of marks as a value as value</param>
        public Placement(Dictionary<string, Dictionary<int, int[]>> rating, int number_of_judges)
        {
            this.number_of_judges = number_of_judges;
            this.rating = rating;
            this.rating_copy = rating;
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

            Dictionary<string, Dictionary<int, int[]>> rating_tmp_copy = new Dictionary<string, Dictionary<int, int[]>>();
            foreach (Dance dance in dances)
            {
                Dictionary<int, int[]> pairs = new Dictionary<int, int[]>();
                for (int i = 0; i < dance.Couples_nums.Length; i++)
                {
                    pairs.Add(dance.Couples_nums[i], dance.Marks[i]);
                }
                rating_tmp_copy.Add(dance.Dance_title, pairs);
            }
            this.rating_copy = rating_tmp_copy;
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

            Dictionary<int, int> placement = new Dictionary<int, int>();
            Dictionary<int, List<int>> collisions = new Dictionary<int, List<int>>();
            var ordered = total.OrderBy(x => x.Value).ToList();
            for (int i = 0; i < ordered.Count; i++)
            {
                var tmp2 = ordered.Where(x => x.Value == ordered[i].Value).ToDictionary(x => x.Key, x => x.Value).Keys.ToList();
                collisions.Add(i + 1, tmp2);
                i += tmp2.Count - 1;
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
                    for (int i = placement.Count; i < collision.Key - 1; i++)
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
                            int lowest_sum = int.MaxValue;
                            List<int> same_sums = new List<int>();
                            foreach (var pair in dancers_numbers)
                            {
                                if (pair.Value < lowest_sum)
                                {
                                    same_sums = new List<int> { pair.Key };
                                    lowest_sum = pair.Value;
                                }
                                else if (pair.Value == lowest_sum)
                                {
                                    same_sums.Add(pair.Key);
                                }
                            }

                            if (same_sums.Count == 1)
                            {
                                placement.Add(same_sums.First(), placement.Count + 1);
                                collision.Value.Remove(same_sums.First());
                            }
                            else
                            {
                                // Rule 11
                                Dictionary<int, int[]> all_dances = new Dictionary<int, int[]>();
                                foreach (var dance in rating_copy)
                                {
                                    foreach (var pair in dance.Value)
                                    {
                                        if (collision.Value.Contains(pair.Key))
                                        {
                                            if (!all_dances.TryAdd(pair.Key, pair.Value))
                                            {
                                                all_dances[pair.Key] = all_dances[pair.Key].Concat(pair.Value).ToArray();
                                            }
                                        }
                                    }
                                }

                                var final_results = EvaluateDanceRule11(all_dances);
                                var ordered_final = final_results.OrderBy(x => x.Value).ToList();

                                int placement_count = placement.Count;
                                foreach (var pair in ordered_final)
                                {
                                    placement.Add(pair.Key, placement_count + pair.Value);
                                }

                                collision.Value.Clear();
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
                Dictionary<int, int> dancers_numbers = FindMajority(dance, stage);
                if (dancers_numbers.Count == 1)
                {
                    order.Add(dancers_numbers.Keys.First(), order.Count + 1);
                    dance.Remove(dancers_numbers.Keys.First());
                    stage = 1;
                    continue;
                }
                else if (dancers_numbers.Count > 1)
                {
                    // Rule 7
                    int lowest_sum = int.MaxValue;
                    List<int> same_sums = new List<int>();
                    foreach (var dancer in dancers_numbers)
                    {
                        if (dancer.Value < lowest_sum)
                        {
                            same_sums = new List<int> { dancer.Key };
                            lowest_sum = dancer.Value;
                        }
                        else if (dancer.Value == lowest_sum)
                        {
                            same_sums.Add(dancer.Key);
                        }
                    }

                    if (same_sums.Count == 1)
                    {
                        order.Add(same_sums.First(), order.Count + 1);
                        dance.Remove(same_sums.First());
                        stage = 1;
                        continue;
                    }
                    else
                    {
                        // Rule 7b
                        var only_colliding_dancers_marks = new Dictionary<int, int[]>();
                        foreach (var dancer in dance)
                        {
                            if (dancers_numbers.Keys.Contains(dancer.Key))
                            {
                                only_colliding_dancers_marks.Add(dancer.Key, dancer.Value);
                            }
                        }
                        while (stage <= number_of_judges)
                        {
                            Dictionary<int, int> colliding_dancers_numbers = FindMajority(only_colliding_dancers_marks, ++stage);
                            if (colliding_dancers_numbers.Count == 1)
                            {
                                order.Add(colliding_dancers_numbers.Keys.First(), order.Count + 1);
                                dance.Remove(colliding_dancers_numbers.Keys.First());
                                break;
                            }
                            else
                            {
                                int lowest_sum_colliding = int.MaxValue;
                                List<int> same_sums_colliding = new List<int>();
                                foreach (var dancer in colliding_dancers_numbers)
                                {
                                    if (dancer.Value < lowest_sum_colliding)
                                    {
                                        same_sums_colliding = new List<int> { dancer.Key };
                                        lowest_sum_colliding = dancer.Value;
                                    }
                                    else if (dancer.Value == lowest_sum_colliding)
                                    {
                                        same_sums_colliding.Add(dancer.Key);
                                    }
                                }

                                if (same_sums_colliding.Count == 1)
                                {
                                    order.Add(same_sums_colliding.First(), order.Count + 1);
                                    dance.Remove(same_sums_colliding.First());
                                    break;
                                }
                            }
                        }

                        if (stage > number_of_judges)
                        {
                            int total = 0;
                            for (int i = 1; i <= dancers_numbers.Count; i++)
                            {
                                total += order.Count + i;
                            }
                            float placement = (float)total / dancers_numbers.Count;

                            foreach (int dancers_number in dancers_numbers.Keys)
                            {
                                order.Add(dancers_number, placement);
                                dance.Remove(dancers_number);
                            }
                        }
                        stage = 1;
                        continue;
                    }
                }
                stage++;
            }

            return order;
        }
        
        /// <summary>
        /// Evaluates a single dance
        /// Can be used outside of class if the right input is guaranteed.
        /// </summary>
        /// <param name="dance">A dance you want to evaluate</param>
        /// <returns>Dictionary with dancers numbers as key with their mark as value</returns>
        private Dictionary<int, int> EvaluateDanceRule11(Dictionary<int, int[]> dance)
        {
            Dictionary<int, int> order = new Dictionary<int, int>();

            int stage = 1;
            while (dance.Count > 0)
            {
                Dictionary<int, int> dancers_numbers = FindMajority(dance, stage);
                if (dancers_numbers.Count == 1)
                {
                    order.Add(dancers_numbers.Keys.First(), order.Count + 1);
                    dance.Remove(dancers_numbers.Keys.First());
                    stage = 1;
                    continue;
                }
                else if (dancers_numbers.Count > 1)
                {
                    // Rule 7
                    int lowest_sum = int.MaxValue;
                    List<int> same_sums = new List<int>();
                    foreach (var dancer in dancers_numbers)
                    {
                        if (dancer.Value < lowest_sum)
                        {
                            same_sums = new List<int> { dancer.Key };
                            lowest_sum = dancer.Value;
                        }
                        else if (dancer.Value == lowest_sum)
                        {
                            same_sums.Add(dancer.Key);
                        }
                    }

                    if (same_sums.Count == 1)
                    {
                        order.Add(same_sums.First(), order.Count + 1);
                        dance.Remove(same_sums.First());
                        stage = 1;
                        continue;
                    }
                    else
                    {
                        // Rule 7b
                        var only_colliding_dancers_marks = new Dictionary<int, int[]>();
                        foreach (var dancer in dance)
                        {
                            if (dancers_numbers.Keys.Contains(dancer.Key))
                            {
                                only_colliding_dancers_marks.Add(dancer.Key, dancer.Value);
                            }
                        }
                        while (stage <= number_of_judges)
                        {
                            Dictionary<int, int> colliding_dancers_numbers = FindMajority(only_colliding_dancers_marks, ++stage);
                            if (colliding_dancers_numbers.Count == 1)
                            {
                                order.Add(colliding_dancers_numbers.Keys.First(), order.Count + 1);
                                dance.Remove(colliding_dancers_numbers.Keys.First());
                                break;
                            }
                            else
                            {
                                int lowest_sum_colliding = int.MaxValue;
                                List<int> same_sums_colliding = new List<int>();
                                foreach (var dancer in colliding_dancers_numbers)
                                {
                                    if (dancer.Value < lowest_sum_colliding)
                                    {
                                        same_sums_colliding = new List<int> { dancer.Key };
                                        lowest_sum_colliding = dancer.Value;
                                    }
                                    else if (dancer.Value == lowest_sum_colliding)
                                    {
                                        same_sums_colliding.Add(dancer.Key);
                                    }
                                }

                                if (same_sums_colliding.Count == 1)
                                {
                                    order.Add(same_sums_colliding.First(), order.Count + 1);
                                    dance.Remove(same_sums_colliding.First());
                                    break;
                                }
                            }
                        }

                        if (stage > number_of_judges)
                        {
                            int order_count = order.Count;

                            foreach (int dancers_number in dancers_numbers.Keys)
                            {
                                order.Add(dancers_number, order_count + 1);
                                dance.Remove(dancers_number);
                            }
                        }
                        stage = 1;
                        continue;
                    }
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
        private Dictionary<int, int> FindMajority(Dictionary<int, int[]> dance, int stage)
        {
            int max_count = 0;
            Dictionary<int, int> dancers_numbers = new Dictionary<int, int>();

            foreach (var dancer in dance)
            {
                int count = 0;
                int sum = 0;
                foreach (int mark in dancer.Value)
                {
                    if (mark <= stage)
                    {
                        count++;
                        sum += mark;
                    }
                }

                if (count > max_count)
                {
                    max_count = count;
                    dancers_numbers = new Dictionary<int, int> { { dancer.Key, sum } };
                }
                else if (count == max_count)
                {
                    dancers_numbers.Add(dancer.Key, sum);
                }
            }

            if (max_count > number_of_judges / 2)
            {
                return dancers_numbers;
            }
            else
            {
                return new Dictionary<int, int>();
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
