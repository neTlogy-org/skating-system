using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skating_system
{
    struct Tanecnik
    {
        public int[] skore;
        public int cislo;

        public Tanecnik(int[] skore, int cislo)
        {
            this.skore = skore;
            this.cislo = cislo;
        }
    }

    internal class Placement
    {
        // tance, porotce - sloupec, tanecnik - radek
        List<List<Tanecnik>> hodnoceni;

        public Placement(List<List<Tanecnik>> hodnoceni)
        {
            this.hodnoceni = hodnoceni;
        }

        public Dictionary<int, int> Vyhodnotit()
        {
            List<List<int>> results = new List<List<int>>();
            for (int i = 0; i < hodnoceni.Count; i++)
            {
                results.Add(VyhodnotitTanec(hodnoceni[i]));
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

        public List<int> VyhodnotitTanec(List<Tanecnik> tanec)
        {
            List<int> poradi = new List<int>();

            int stage = 1;
            while (tanec.Count > 0)
            {
                int i = NajitVetsinu(tanec, stage);
                if (i >= 0)
                {
                    poradi.Add(tanec[i].cislo);
                    tanec.RemoveAt(i);
                }
                stage++;
            }

            return poradi;
        }

        private int NajitVetsinu(List<Tanecnik> tanec, int stage)
        {
            int max_pocet = 0, index = 0;

            for (int i = 0; i < tanec.Count; i++)
            {
                int pocet = 0;
                foreach (int znamka in tanec[i].skore)
                {
                    if (znamka <= stage)
                    {
                        pocet++;
                    }
                }

                if (pocet > max_pocet)
                {
                    max_pocet = pocet;
                    index = i;
                }
            }

            if (max_pocet >= tanec.Count / 2)
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
