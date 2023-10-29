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
        public List<int> tied_pairs = new List<int>();
        public Dictionary<int, List<int>> tied_positions = new Dictionary<int, List<int>>();

        public Results(Dictionary<string, Dictionary<int, float>> individual, Dictionary<int, float> total, Dictionary<int, Dictionary<string, string>> rating, Dictionary<int, int> placement, List<int> tied_pairs, Dictionary<int, List<int>> tied_positions)
        {
            this.total = total;
            this.individual = individual;
            this.rating = rating;
            this.placement = placement;
            this.tied_pairs = tied_pairs;
            this.tied_positions = tied_positions;

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

            // TODO: Check for rule 10
            Dictionary<int, int> placement = new Dictionary<int, int>();
            List<int> tied_pairs = new List<int>();
            Dictionary<int, List<int>> tied_positions = new Dictionary<int, List<int>>();

            var res = CalculatePlacements(individual);
            placement = res.Item1;
            tied_pairs = res.Item2;
            tied_positions = res.Item3;
            

            /*var ordered = total.OrderBy(x => x.Value).ToList();
            List<int> collision = new List<int>();
            for (int i = 0; i < ordered.Count - 1; i++)
            {
                if (ordered[i].Value == ordered[i + 1].Value)
                {
                    collision.Add(i);
                    collision.Add(++i);
                }
            }

            if (collision.Count == 0)
            {
                for (int i = 0; i < ordered.Count; i++)
                {
                    placement.Add(ordered[i].Key, i + 1);
                }
            }
            else
            {
                Check(collision, individual, total); // Check here
            }*/

            return new Results(individual, total, rating_tmp, placement, tied_pairs, tied_positions);
        }

        public static (Dictionary<int, int>, List<int>, Dictionary<int, List<int>>) CalculatePlacements(Dictionary<string, Dictionary<int, float>> individual)
        {
            // Vytvoření slovníku pro celkové umístění
            Dictionary<int, int> placement = new Dictionary<int, int>();
            List<int> tiedPairs = new List<int>();
            Dictionary<int, List<int>> sharedPlacement = new Dictionary<int, List<int>>();

            // Suma umístění pro každý pár
            foreach (var dance in individual)
            {
                foreach (var pair in dance.Value)
                {
                    if (!placement.ContainsKey(pair.Key))
                        placement[pair.Key] = 0;
                    placement[pair.Key] += (int)pair.Value;
                }
            }

            // Výpočet konečného umístění s rozlišením remíz
            CalculateFinalPlacements(individual, ref placement, tiedPairs, sharedPlacement);

            return (placement, tiedPairs.Distinct().ToList(), sharedPlacement);
        }

        private static void CalculateFinalPlacements(
            Dictionary<string, Dictionary<int, float>> individual,
            ref Dictionary<int, int> placement,
            List<int> tiedPairs,
            Dictionary<int, List<int>> sharedPlacement)
        {
            var sortedPairs = placement.ToList();
            sortedPairs.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value)); // Seřadit podle skóre

            for (int i = 0; i < sortedPairs.Count; i++)
            {
                for (int j = i + 1; j < sortedPairs.Count; j++)
                {
                    if (sortedPairs[i].Value == sortedPairs[j].Value) // Pokud mají stejné skóre
                    {
                        if (!ResolveTie(individual, sortedPairs[i].Key, sortedPairs[j].Key, tiedPairs))
                        {
                            tiedPairs.Add(sortedPairs[i].Key);
                            tiedPairs.Add(sortedPairs[j].Key);
                            AddToSharedPlacement(sharedPlacement, i + 1, sortedPairs[i].Key, sortedPairs[j].Key);
                        }
                        else // Rozhodnuto pravidly 10a nebo 10b
                        {
                            if (sortedPairs[i].Value < sortedPairs[j].Value)
                            {
                                // Swap if pair2 has better score after applying rules 10a or 10b
                                var temp = sortedPairs[i];
                                sortedPairs[i] = sortedPairs[j];
                                sortedPairs[j] = temp;
                            }
                        }
                    }
                }
            }

            // Update final placement
            for (int i = 0; i < sortedPairs.Count; i++)
            {
                placement[sortedPairs[i].Key] = i + 1; // Upravit umístění na základě konečného řazení
            }
        }

        private static void AddToSharedPlacement(Dictionary<int, List<int>> sharedPlacement, int placement, params int[] pairs)
        {
            if (!sharedPlacement.ContainsKey(placement))
            {
                sharedPlacement[placement] = new List<int>();
            }

            foreach (var pair in pairs)
            {
                if (!sharedPlacement[placement].Contains(pair))
                {
                    sharedPlacement[placement].Add(pair);
                }
            }
        }

        private static bool ResolveTie(
            Dictionary<string, Dictionary<int, float>> individual,
            int pair1,
            int pair2,
            List<int> tiedPairs)
        {
            var danceCounts1 = CountBetterOrEqualPlacements(individual, pair1);
            var danceCounts2 = CountBetterOrEqualPlacements(individual, pair2);

            if (danceCounts1.Count > danceCounts2.Count)
            {
                return true; // pair1 vítězí
            }
            else if (danceCounts2.Count > danceCounts1.Count)
            {
                return true; // pair2 vítězí
            }

            // Pravidlo 10b: Kontrola součtu umístění
            var sumPlacements1 = danceCounts1.Sum(kv => kv.Value);
            var sumPlacements2 = danceCounts2.Sum(kv => kv.Value);

            return sumPlacements1 != sumPlacements2; // Rozhodnuto, pokud nejsou součty stejné
        }

        private static Dictionary<int, float> CountBetterOrEqualPlacements(
            Dictionary<string, Dictionary<int, float>> individual,
            int pair)
        {
            return individual
                .SelectMany(dance => dance.Value.Where(p => p.Key == pair && p.Value <= individual[dance.Key][pair]))
                .GroupBy(p => p.Key)
                .ToDictionary(group => group.Key, group => group.Sum(p => p.Value));
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
    }
}
