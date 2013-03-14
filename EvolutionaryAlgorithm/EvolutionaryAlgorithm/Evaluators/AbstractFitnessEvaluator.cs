using System.Collections.Generic;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Evaluators
{
    public abstract class AbstractFitnessEvaluator
    {
        public abstract void CalculateFitness(AbstractPhenotype phenotype);
        public abstract void CalculatePopulationFitness(List<AbstractPhenotype> phenotypes);
    }
}