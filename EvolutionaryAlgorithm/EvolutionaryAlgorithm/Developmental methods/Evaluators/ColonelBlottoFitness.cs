using System.Collections.Generic;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Evaluators
{
    public class ColonelBlottoFitness : AbstractFitnessEvaluator
    {
        public override void CalculateFitness(AbstractPhenotype phenotype)
        {
            var cbp = (ColonelBlottoPhenotype) phenotype;
            cbp.Fitness = (cbp.Wins*2) + cbp.Ties;

            cbp.Wins = 0;
            cbp.Ties = 0;
        }

        public override void CalculatePopulationFitness(List<AbstractPhenotype> phenotypes)
        {
            foreach (AbstractPhenotype p in phenotypes)
            {
                CalculateFitness(p);
            }
        }
    }
}