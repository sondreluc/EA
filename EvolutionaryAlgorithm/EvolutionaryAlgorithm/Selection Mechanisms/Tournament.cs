using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Selection_Mechanisms
{
    public class Tournament:AbstractSelectionMechanism
    {
        private readonly Random _random;

        public Tournament()
        {
            _random = new Random();
        }
        public override void NormalizeRouletteWheel(List<AbstractPhenotype> adults)
        {
            throw new NotImplementedException();
        }

        public override List<AbstractPhenotype> TournamentSelection(List<AbstractPhenotype> adults, int numberToSelect, int k, double e)
        {
            
            List<AbstractPhenotype> parents = new List<AbstractPhenotype>();
            List<AbstractPhenotype> selected = new List<AbstractPhenotype>();

            for (int i = 0; i < numberToSelect; i++)
            {
                List<AbstractPhenotype> copy = new List<AbstractPhenotype>();
                copy.AddRange(adults);
                for (int j = 0; j < k; j++)
                {
                    int randomIndex = _random.Next(0, copy.Count);
                    parents.Add(copy[randomIndex]);
                    copy.RemoveAt(randomIndex);
                }
            
                double randomDouble = _random.NextDouble();

                if (randomDouble < e)
                {
                    selected.Add(parents.ElementAt(_random.Next(0, parents.Count)));
                }
                else
                {
                    var max = parents.Max(x => x.Fitness);
                    selected.Add(parents.FirstOrDefault(x => x.Fitness >= max));
                }
            }
            return selected;
        }
    }
}
