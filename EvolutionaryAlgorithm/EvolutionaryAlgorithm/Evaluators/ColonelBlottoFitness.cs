using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Evaluators
{
    public class ColonelBlottoFitness:AbstractFitnessEvaluator
    {
        public override void CalculateFitness(AbstractPhenotype phenotype)
        {
            var cbp = (ColonelBlottoPhenotype) phenotype;
            cbp.Fitness = (cbp.Wins * 2) + cbp.Ties;

            cbp.Wins = 0;
            cbp.Ties = 0;
        }

        public override void CalculatePopulationFitness(List<AbstractPhenotype> phenotypes)
        {
            foreach (var p in phenotypes)
            {
                CalculateFitness(p);
            }
 
        }
    }
}
