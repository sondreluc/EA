using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Selection_Mechanisms
{
    public class Rank : AbstractSelectionMechanism
    {
        public override void NormalizeRouletteWheel(List<AbstractPhenotype> adults)
        {
            double min = adults.Min(x => x.Fitness);
            double max = adults.Max(x => x.Fitness);
            double rouletteProportion = 0;
            double rankSum = 0;
            adults.Sort();
            for (int i = 1; i < adults.Count + 1; i++)
            {
                rankSum += (min + ((max - min)*((double) (i - 1)/(adults.Count - 1))));
            }

            for (int i = 1; i < adults.Count + 1; i++)
            {
                rouletteProportion += (min + ((max - min)*((double) (i - 1)/(adults.Count - 1))))/(rankSum);
                adults[i - 1].RouletteProportion = rouletteProportion;
            }
        }

        public override List<AbstractPhenotype> TournamentSelection(List<AbstractPhenotype> adults, int numberToSelect,
                                                                    int k, double e)
        {
            throw new NotImplementedException();
        }
    }
}