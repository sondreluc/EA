using System;
using System.Collections.Generic;
using EvolutionaryAlgorithm.Phenotypes;
using EvolutionaryAlgorithm.Evaluators.MinCogSimulator;

namespace EvolutionaryAlgorithm.Evaluators
{
    internal class MinCogFitness : AbstractFitnessEvaluator
    {
        public override void CalculateFitness(AbstractPhenotype phenotype)
        {
            var sim = new MinCogSimulator.MinCogSimulator((MinCogPhenotype)phenotype);
            sim.Simulate();
        }

        public override void CalculatePopulationFitness(List<AbstractPhenotype> phenotypes)
        {
            throw new NotImplementedException();
        }
    }
}