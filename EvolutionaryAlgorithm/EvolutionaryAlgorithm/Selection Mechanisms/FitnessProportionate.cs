using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Selection_Mechanisms
{
    public class FitnessProportionate : AbstractSelectionMechanism
    {
        public override void NormalizeRouletteWheel(List<AbstractPhenotype> adults)
        {
            double fitnessSum = adults.Sum(x => x.Fitness);
            double rouletteProportion = 0;

            foreach (AbstractPhenotype adult in adults)
            {
                double normalizedFitness = (adult.Fitness/fitnessSum);
                rouletteProportion += normalizedFitness;
                adult.RouletteProportion = rouletteProportion;
            }
        }

        public override List<AbstractPhenotype> TournamentSelection(List<AbstractPhenotype> adults, int numberToSelect,
                                                                    int k, double e)
        {
            throw new NotImplementedException();
        }
    }
}