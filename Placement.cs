using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skating_system
{
    struct Dancer
    {
        public int[] score;
        public int starting_number;

        public Dancer(int[] score, int starting_number)
        {
            this.score = score;
            this.starting_number = starting_number;
        }
    }

    internal class Placement
    {
        // tance, porotce - sloupec, tanecnik - radek
        List<List<Dancer>> rating;

        public Placement(List<List<Dancer>> rating)
        {
            this.rating = rating;
        }

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

        public List<int> EvaluateDance(List<Dancer> dance)
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

        private int FindMajority(List<Dancer> dance, int stage)
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
