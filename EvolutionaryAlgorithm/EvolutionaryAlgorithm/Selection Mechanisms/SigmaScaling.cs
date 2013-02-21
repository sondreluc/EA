using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Selection_Mechanisms
{
    public class SigmaScaling:AbstractSelectionMechanism
    {

        public override void NormalizeRouletteWheel(List<AbstractPhenotype> adults)
        {
            var average = adults.Average(x => x.Fitness);
            var standardDeviation = Math.Sqrt(adults.Sum(x => Math.Pow((x.Fitness - average), 2))/adults.Count);

            double rouletteProportion = 0;

            if (standardDeviation <= 0.0)
            {
                double normalizedValue = 1.0/adults.Count;
                foreach (var adult in adults)
                {
                    rouletteProportion += normalizedValue;
                    adult.RouletteProportion = rouletteProportion;
                }
            }
            else
            {
                double sigmaSum = adults.Sum(x => (1 + ((x.Fitness - average)/(2*standardDeviation))));
    
                foreach (var adult in adults)
                {
                    double normalizedValue = (1 + ((adult.Fitness - average)/(2*standardDeviation)))/sigmaSum;
                    rouletteProportion += normalizedValue;
                    adult.RouletteProportion = rouletteProportion;
                }
            }
            
        }

        public override List<AbstractPhenotype> TournamentSelection(List<AbstractPhenotype> adults, int numberToSelect, int k, double e)
        {
            throw new NotImplementedException();
        }
    }
}
